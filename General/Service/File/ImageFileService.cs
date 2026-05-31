using Domain.Exception;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.TaskService.BaseTaskService;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using YandexDisk.Client.Http;
using YandexDisk.Client.Protocol;

namespace General.Service.File;

public class ImageFileService(ILogSaver debugLog) : IImageFileService
{
    private const string TitleManager = "Выберите изображения мероприятия";
    private const string FilesPictureBox = "Выберите изображения PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
    private const string Token = "y0__wgBEM-k-rgGGNuOQiDKrpHOF-xTZypvzN7RuIc98EIRpZBt0qkG";
    private const string TargetFolder = "Images";
    private const string LocalFolder = "ImageGraduareProject\\";

    private readonly string _localDirectoryTemp = Path.GetTempPath() + LocalFolder;
    private readonly List<string> _tempFiles = new();

    public IEnumerable<Task<PathImageValidObject>> SaveImagesToDisk(IEnumerable<PathImageValidObject>? paths, CancellationToken cancellationToken) 
        => paths?.Select(i => SaveImageToDick(i, cancellationToken));

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
        if (!string.IsNullOrEmpty(path.CloudPath)) return path;

        var pathYandexDisk = $"/{TargetFolder}/{Guid.NewGuid()}{Path.GetExtension(path.LocalPath)}";
        SaveImageToDickAsync(path.LocalPath, pathYandexDisk);

        return new PathImageValidObject(path.LocalPath, pathYandexDisk);
    }

    public async Task SaveImageToDickAsync(string pathLocal, string pathYandexDisk)
    {
        try
        {
            using (var fileStream = System.IO.File.OpenRead(pathLocal))
            {
                try
                {
                    var api = new DiskHttpApi(Token, debugLog);
                    var link = await api.Files.GetUploadLinkAsync(pathYandexDisk, false);
                    await api.Files.UploadAsync(link, fileStream);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private async Task DownloadImageToMemory(string nameImageYandexDisk, string pathLocalImage, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var api = new DiskHttpApi(Token, debugLog);
        var link = await api.Files.GetDownloadLinkAsync(nameImageYandexDisk, cancellationToken);

        cancellationToken.ThrowIfCancellationRequested();

        await using var stream = await api.Files.DownloadAsync(link, cancellationToken);

        cancellationToken.ThrowIfCancellationRequested();

        await using var fileStream = new FileStream(pathLocalImage, FileMode.Create, FileAccess.Write);
        await stream.CopyToAsync(fileStream, cancellationToken);

        cancellationToken.ThrowIfCancellationRequested();

        RegisterTempFileForCleanup(pathLocalImage);
    }

    private async Task RegisterTempFileForCleanup(string filePath)
    {
        _tempFiles.Add(filePath);
        AppDomain.CurrentDomain.ProcessExit += (s, e) => CleanupTempFiles();
    }
    private async Task CleanupTempFiles()
    {
        foreach (var file in _tempFiles)
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);
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
        if (string.IsNullOrEmpty(path.CloudPath)) return;

        var api = new DiskHttpApi(Token, debugLog);
        var deleteRequest = new DeleteFileRequest { Path = path.CloudPath, Permanently = true };

        if (cancellationToken.IsCancellationRequested) return;

        try
        {
            api.Commands.DeleteAsync(deleteRequest, cancellationToken);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка удаления файла '{path.CloudPath}': {ex.Message}");
            throw;
        }
    }
}