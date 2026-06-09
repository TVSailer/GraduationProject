using Domain.Enum;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using System.Diagnostics;
using Domain.ValidObject;

namespace Domain.Service.ImageService;

public class InfoImage
{
    public PathImageValidObject Path { get; set; }

    public bool IsToggle { get; set; }
    public bool IsRemove { get; set; }

    public InfoImage(string localPath, string cloudPath = null)
    {
        Path = new PathImageValidObject(localPath, cloudPath);
    }

    public InfoImage(PathImageValidObject path)
    {
        Path = path;
    }
}

public class ImageService(IMessageService messageService, IImageFileService imageFileService)
    : IImageService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private PathImageValidObject? _imagePath;
    private CustomPropertyInfo<string>? _propertyInfoImageLocalPath;

    public event Action<IEnumerable<string>>? OnChangeImg;
    public readonly List<InfoImage> Images = [];

    public void AddImage()
    {
        var images = imageFileService.ShowOpenFileDialog();
        if (images == null) return;
        foreach (var localPath in images)
            Images.Add(new InfoImage(localPath));

        NotifyImagesChanged();
    }

    public void RemoveIsValueImages()
    {
        if (!Images.Any(i => i.IsToggle)) return;

        foreach (var selecteRemoveImage in Images.Where(i => i.IsToggle))
            selecteRemoveImage.IsRemove = true;

        NotifyImagesChanged();
    }

    public IEnumerable<Task<PathImageValidObject>> SaveImagesToDisk()
        => imageFileService.SaveImagesToDisk(  
            Images.Where(i => !i.IsRemove).Select(i => i.Path),
            _cancellationTokenSource.Token);

    public void ToggleImage(string path)
    {
        var key = Images.Single(i => i.Path.LocalPath == path);
        key.IsToggle = !key.IsToggle;
    }

    public Task BindingImages(object obj, string nameMember, IEnumerable<string>? cloudPaths = null)
    {
        var prop = obj.GetType().GetProperty(nameMember)
            ?? throw new ArgumentException($"Property '{nameMember}' not found on type '{obj.GetType().Name}'");

        OnChangeImg += imagesList => prop.SetValue(obj, imagesList);

        if (cloudPaths is null) return Task.CompletedTask;

        foreach (var cloudPath in cloudPaths)
            Images.Add(new InfoImage(new PathImageValidObject(cloudPath)));

        LoadImagesAsync().FireAndForget();
        return Task.CompletedTask;
    }

    private async Task LoadImagesAsync()
    {
        foreach (var image in Images)
        {
            try
            {
                image.Path = await imageFileService.GetFullPath(image.Path.CloudPath, _cancellationTokenSource.Token);
                NotifyImagesChanged();
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (System.Exception ex)
            {
                messageService.Message($"Ошибка загрузки изображения: {ex.Message}", TypeMessage.Error);
            }
        }
    }

    public async Task BindingImage(object obj, string nameMember, string? url = null)
    {
        _propertyInfoImageLocalPath = new CustomPropertyInfo<string>(obj, nameMember);

        try
        {
            _imagePath = await imageFileService.GetFullPath(url, _cancellationTokenSource.Token);
            if (_imagePath is not null)
                _propertyInfoImageLocalPath.SetValue(_imagePath.LocalPath);
        }
        catch (OperationCanceledException)
        {
            // Операция была отменена, игнорируем
        }
        catch (System.Exception ex)
        {
            messageService.Message($"Ошибка загрузки фото: {ex.Message}", TypeMessage.Error);
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
            await imageFileService.DeleteImageFromDisk(_imagePath, _cancellationTokenSource.Token);

        return await imageFileService.SaveImageToDick(
            new PathImageValidObject(imageLocalPath),
            _cancellationTokenSource.Token);
    }

    public async Task<List<string>> UpdateImagesFromCloudDisk()
    {
        await DeleteImagesFromDisk();

        var images = new List<string>();

        foreach (var pathImageTask in SaveImagesToDisk())
        {
            var pathImage = await pathImageTask.ConfigureAwait(false);

            if (pathImage.CloudPath is null)
                throw new InvalidOperationException("PathImage must have a CloudPath");

            images.Add(pathImage.CloudPath);
        }

        return images;
    }

    private async Task DeleteImagesFromDisk()
    {
        foreach (var kvp in Images.Where(i => i.IsRemove && i.Path.LocalPath is not null).ToList())
        {
            Images.Remove(kvp);
            await imageFileService.DeleteImageFromDisk(kvp.Path, _cancellationTokenSource.Token);
        }
    }

    public Task ClearImages()
    {
        foreach (var kvp in Images.ToArray())
        {
            imageFileService.DeleteImageFromDisk(kvp.Path, _cancellationTokenSource.Token).FireAndForget();
            Images.Remove(kvp);
        }

        return Task.CompletedTask;
    }

    public Task ClearImage()
    {
        if (_imagePath is not null)
            imageFileService.DeleteImageFromDisk(_imagePath, _cancellationTokenSource.Token).FireAndForget();

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
        => OnChangeImg?.Invoke(Images.Where(i => !i.IsRemove && i.Path.LocalPath is not null).Select(i => i.Path.LocalPath)!);
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