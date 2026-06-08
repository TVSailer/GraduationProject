using Domain.Enum;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using General.Service.File;
using System.Diagnostics;

namespace Domain.Service.ImageService;

public class ImageService : IImageService, IDisposable
{
    private readonly IMessageService _messageService;
    private readonly IImageFileService _imageFileService;
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private PathImageValidObject? _imagePath;
    private CustomPropertyInfo<string>? _propertyInfoImageLocalPath;

    public event Action<IEnumerable<string>>? OnChangeImg;
    public readonly Dictionary<PathImageValidObject, bool> Images = [];

    public ImageService(IMessageService messageService, IImageFileService imageFileService)
    {
        _messageService = messageService;
        _imageFileService = imageFileService;
    }

    public void AddImage()
    {
        var images = _imageFileService.ShowOpenFileDialog();
        if (images == null) return;
        foreach (var image in images)
            Images.TryAdd(new PathImageValidObject(image), false);

        NotifyImagesChanged();
    }

    public void UpdateListImages()
    {
        if (!Images.Any(kvp => kvp.Value)) return;

        NotifyImagesChanged();
    }

    public IEnumerable<Task<PathImageValidObject>> SaveImagesToDisk()
        => _imageFileService.SaveImagesToDisk(
            Images.Where(i => !i.Value).Select(i => i.Key),
            _cancellationTokenSource.Token);

    public void ToggleImage(string path)
    {
        var key = Images.Keys.Single(i => i.LocalPath == path);
        Images[key] = !Images[key];
    }

    public Task BindingImages(object obj, string nameMember, IEnumerable<string>? images = null)
    {
        var prop = obj.GetType().GetProperty(nameMember)
            ?? throw new ArgumentException($"Property '{nameMember}' not found on type '{obj.GetType().Name}'");

        OnChangeImg += imagesList => prop.SetValue(obj, imagesList);

        if (images is null) return Task.CompletedTask;

        LoadImagesAsync(images).FireAndForget();
        return Task.CompletedTask;
    }

    private async Task LoadImagesAsync(IEnumerable<string> images)
    {
        foreach (var image in images)
        {
            try
            {
                var fullPath = await _imageFileService.GetFullPath(image, _cancellationTokenSource.Token);
                Images.TryAdd(fullPath, false);
                NotifyImagesChanged();
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (System.Exception ex)
            {
                _messageService.Message($"Ошибка загрузки изображения: {ex.Message}", TypeMessage.Error);
            }
        }
    }

    public async Task BindingImage(object obj, string nameMember, string? url = null)
    {
        _propertyInfoImageLocalPath = new CustomPropertyInfo<string>(obj, nameMember);

        try
        {
            _imagePath = await _imageFileService.GetFullPath(url, _cancellationTokenSource.Token);
            if (_imagePath is not null)
                _propertyInfoImageLocalPath.SetValue(_imagePath.LocalPath);
        }
        catch (OperationCanceledException)
        {
            // Операция была отменена, игнорируем
        }
        catch (System.Exception ex)
        {
            _messageService.Message($"Ошибка загрузки фото: {ex.Message}", TypeMessage.Error);
        }
    }

    public async Task<PathImageValidObject> UpdateImageFromCloudDisk()
    {
        if (_propertyInfoImageLocalPath is null)
            throw new InvalidOperationException("Image binding not initialized");

        var imageLocalPath = _propertyInfoImageLocalPath.GetValue()
            ?? throw new InvalidOperationException("Image local path is null");

        if (_imagePath?.LocalPath == imageLocalPath)
            return _imagePath;

        if (_imagePath is not null)
            await _imageFileService.DeleteImageFromDisk(_imagePath, _cancellationTokenSource.Token);

        return await _imageFileService.SaveImageToDick(
            new PathImageValidObject(imageLocalPath),
            _cancellationTokenSource.Token);
    }

    public async Task<List<string>> UpdateImagesFromCloudDisk()
    {
        await DeleteImagesFromDisk();

        var images = new List<string>();

        foreach (var pathImageTask in SaveImagesToDisk())
        {
            var pathImage = await pathImageTask;

            if (pathImage.CloudPath is null)
                throw new InvalidOperationException("PathImage must have a CloudPath");

            images.Add(pathImage.CloudPath);
        }

        return images;
    }

    private async Task DeleteImagesFromDisk()
    {
        foreach (var kvp in Images.Where(i => i.Value).Select(i => i.Key).ToList())
        {
            await _imageFileService.DeleteImageFromDisk(kvp, _cancellationTokenSource.Token);
            Images.Remove(kvp);
        }
    }

    public Task ClearImages()
    {
        foreach (var kvp in Images.Keys.ToList())
        {
            _imageFileService.DeleteImageFromDisk(kvp, _cancellationTokenSource.Token).FireAndForget();
            Images.Remove(kvp);
        }

        return Task.CompletedTask;
    }

    public Task ClearImage()
    {
        if (_imagePath is not null)
            _imageFileService.DeleteImageFromDisk(_imagePath, _cancellationTokenSource.Token).FireAndForget();

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        OnChangeImg = null;
        GC.SuppressFinalize(this);
    }

    private void NotifyImagesChanged()
        => OnChangeImg?.Invoke(Images.Select(i => i.Key.LocalPath));
}

// Вспомогательный extension method для fire-and-forget операций
public static class TaskExtensions
{
    public static async void FireAndForget(this Task task)
    {
        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            // Операция отменена
        }
        catch (System.Exception ex)
        {
            
            // Логирование можно добавить при необходимости
            Debug.WriteLine(ex.Message);
        }
    }
}