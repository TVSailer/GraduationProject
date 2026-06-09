using Domain.Enum;
using Domain.Service.DebugService.BaseDebugService;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MessageService.BaseMessageService;
using System.Diagnostics;
using System.Windows.Forms;
using Domain.ValidObject;
using YandexDisk.Client.Http;
using YandexDisk.Client.Protocol;

namespace General.Service.File;

public class ImageFileService : IImageFileService
{
    private const string TitleManager = "Выберите изображения мероприятия";
    private const string FilesPictureBox = "Выберите изображения PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
    private const string TargetFolder = "Images";
    private const string LocalFolder = "ImageGraduareProject\\";

    private readonly string Token;
    private readonly string _localDirectoryTemp = Path.GetTempPath() + LocalFolder;
    private readonly List<string> _tempFiles = new();
    private readonly ILogSaver _debugLog;
    private readonly IMessageService _messageService;
    private readonly IDebugLogService _debugLogService;

    private readonly SemaphoreSlim _cleanupLock = new(1, 1);

    public ImageFileService(ILogSaver debugLog, IMessageService messageService, IDebugLogService debugLogService)
    {
        _debugLog = debugLog ?? throw new ArgumentNullException(nameof(debugLog));
        _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        _debugLogService = debugLogService ?? throw new ArgumentNullException(nameof(debugLogService));
        _localDirectoryTemp = Path.Combine(Path.GetTempPath(), LocalFolder);

        var settingYandex = new YandexDiskSettings();
        Token = settingYandex.Token;

        // Подписываемся на очистку при выходе
        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
    }

    public IEnumerable<Task<PathImageValidObject>> SaveImagesToDisk(
        IEnumerable<PathImageValidObject>? paths,
        CancellationToken cancellationToken)
    {
        return paths?.Select(i => SaveImageToDick(i, cancellationToken)) ?? [];
    }

    public string[]? ShowOpenFileDialog(bool multiselect = true)
    {
        using var openFileDialog = new OpenFileDialog()
        {
            Filter = FilesPictureBox,
            Title = TitleManager,
            Multiselect = multiselect
        };
        return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileNames : null;
    }

    public async Task<PathImageValidObject> SaveImageToDick(PathImageValidObject path, CancellationToken cancellationToken)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        if (!string.IsNullOrEmpty(path.CloudPath)) return path;
        if (path.LocalPath is null) throw new ArgumentNullException(nameof(path.LocalPath));

        var pathYandexDisk = $"/{TargetFolder}/{Guid.NewGuid()}{Path.GetExtension(path.LocalPath)}";

        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            await SaveImageToDickAsync(path.LocalPath, pathYandexDisk, cancellationToken);

            return new PathImageValidObject(path.LocalPath, pathYandexDisk);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _messageService.Message("Ошибка при сохранении изображения: " + ex.Message, TypeMessage.Error);
            _debugLogService.Message("SaveImageToDick failed" + ex);
            throw;
        }
    }

    private async Task SaveImageToDickAsync(string pathLocal, string pathYandexDisk, CancellationToken cancellationToken)
    {
        if (!System.IO.File.Exists(pathLocal))
            throw new FileNotFoundException("Файл не найден", pathLocal);

        var api = CreateDiskApi();

        var fileStream = new FileStream(
            pathLocal,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            81920,
            true);

        await using (fileStream)
        {
            var link = await api.Files.GetUploadLinkAsync(pathYandexDisk, false, cancellationToken).ConfigureAwait(false);
            await api.Files.UploadAsync(link, fileStream, cancellationToken);
        }

        Debug.WriteLine($"Файл загружен: {pathLocal} -> {pathYandexDisk}");
    }

    private async Task DownloadImageToMemory(string nameImageYandexDisk, string pathLocalImage, CancellationToken cancellationToken)
    {
        const int maxRetries = 5;
        Exception? lastException = null;

        for (int i = 0; i < maxRetries; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var api = CreateDiskApi();

                var link = await api.Files.GetDownloadLinkAsync(nameImageYandexDisk, cancellationToken);

                if (link == null)
                    throw new InvalidOperationException("Получена пустая ссылка для скачивания");

                await using var stream = await api.Files.DownloadAsync(link, cancellationToken).ConfigureAwait(false);

                var fileStream = new FileStream(
                    pathLocalImage,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    81920,
                    true);

                await using (fileStream)
                {
                    await stream.CopyToAsync(fileStream, cancellationToken);
                    await fileStream.FlushAsync(cancellationToken);
                }

                if (System.IO.File.Exists(pathLocalImage) && new FileInfo(pathLocalImage).Length > 0)
                {
                    await RegisterTempFileForCleanup(pathLocalImage);
                    Debug.WriteLine($"✓ Изображение скачано (попытка {i + 1}): {nameImageYandexDisk}");
                    return;
                }

                throw new InvalidOperationException("Скачанный файл пуст или не существует");
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex) when (i < maxRetries - 1)
            {
                lastException = ex;
                Debug.WriteLine($"✗ Попытка {i + 1}/{maxRetries}: {ex.Message}");

                await TryDeleteFile(pathLocalImage);

                var delay = TimeSpan.FromSeconds(Math.Pow(2, i - 1));
                await Task.Delay(delay, cancellationToken);
            }
        }

        throw new AggregateException(
            $"Не удалось скачать изображение после {maxRetries} попыток",
            lastException);
    }

    private async Task TryDeleteFile(string filePath)
    {
        try
        {
            if (System.IO.File.Exists(filePath))
            {
                await Task.Run(() => System.IO.File.Delete(filePath));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка удаления временного файла: {ex.Message}");
        }
    }

    private async Task RegisterTempFileForCleanup(string filePath)
    {
        await _cleanupLock.WaitAsync();
        try
        {
            _tempFiles.Add(filePath);
        }
        finally
        {
            _cleanupLock.Release();
        }
    }

    public async Task<PathImageValidObject?> GetFullPath(string? fileNameYandexDisk, CancellationToken cancellationToken)
    {
        if (fileNameYandexDisk is null) return null;

        var extension = Path.GetExtension(fileNameYandexDisk);

        if (!Directory.Exists(_localDirectoryTemp))
            Directory.CreateDirectory(_localDirectoryTemp);

        var tempPath = Path.Combine(_localDirectoryTemp, $"{Guid.NewGuid()}{extension}");
        await DownloadImageToMemory(fileNameYandexDisk, tempPath, cancellationToken);

        return new PathImageValidObject(tempPath, fileNameYandexDisk);
    }

    public async Task DeleteImageFromDisk(PathImageValidObject path, CancellationToken cancellationToken)
    {
        if (path == null)
        {
            _messageService.Message("На удаление пришел пустой path", TypeMessage.Error);
            return;
        }

        if (string.IsNullOrEmpty(path.CloudPath)) return;

        if (cancellationToken.IsCancellationRequested) return;

        try
        {
            var api = CreateDiskApi();
            var deleteRequest = new DeleteFileRequest
            {
                Path = path.CloudPath,
                Permanently = true
            };

            await api.Commands.DeleteAsync(deleteRequest, cancellationToken);
            Debug.WriteLine($"Файл удален с диска: {path.CloudPath}");
        }
        catch (OperationCanceledException)
        {
            // Нормальная отмена
        }
        catch (Exception ex)
        {
            _messageService.Message(
                $"Ошибка удаления файла '{path.CloudPath}': {ex.Message}",
                TypeMessage.Error);
            _debugLogService.Message("DeleteImageFromDisk failed" + ex);
        }
    }

    private DiskHttpApi CreateDiskApi()
    {
        return new DiskHttpApi(Token, _debugLog);
    }

    private void OnProcessExit(object? sender, EventArgs e)
    {
        CleanupTempFiles().GetAwaiter().GetResult();
    }

    private async Task CleanupTempFiles()
    {
        await _cleanupLock.WaitAsync();
        try
        {
            await ClearTempFiles();
        }
        finally
        {
            _cleanupLock.Release();
        }
    }

    public async Task ClearTempFiles()
    {
        foreach (var file in _tempFiles.ToList())
        {
            await TryDeleteFile(file);
        }

        _tempFiles.Clear();
    }

    public void Dispose()
    {
        AppDomain.CurrentDomain.ProcessExit -= OnProcessExit;
        CleanupTempFiles().GetAwaiter().GetResult();
        _cleanupLock.Dispose();
    }
}