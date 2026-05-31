using Domain.Enum;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using General.Service.File;

namespace Domain.Service.ImageService;

public class ImageService(IMessageService messageService,  IImageFileService imageFileService) : IImageService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private PathImageValidObject? _imagePath;

    public event Action<IEnumerable<string>>? OnChangeImg;
    public readonly Dictionary<PathImageValidObject, bool> Images = [];

    public void AddImage()
    {
        foreach (var image in imageFileService.ShowOpenFileDialog())
            Images.TryAdd(new PathImageValidObject(image), false);

        OnChangeImg?
            .Invoke(Images
            .Select(i => i.Key.LocalPath));
    }

    public void UpdateListImages()
    {
        if (!Images.Any(kvp => kvp.Value)) return;

        OnChangeImg?.Invoke(Images
            .Where(i => !Images[i.Key])
            .Select(i => i.Key.LocalPath));
    }

    public IEnumerable<Task<PathImageValidObject>> SaveImagesToDisk()
        =>  imageFileService.SaveImagesToDisk(Images.Where(i => !i.Value).Select(i => i.Key), _cancellationTokenSource.Token);

    public void ToggleImage(string path)
    {
        var key = Images
            .Select(i => i.Key)
            .Single(i => i.LocalPath == path);

        Images[key] = !Images[key];
    }

    public Task BindingImages(object obj, string nameMember, IEnumerable<string>? images = null)
    {
        var prop = obj.GetType().GetProperty(nameMember);

        OnChangeImg += images => prop.SetValue(obj, images);

        if (images is null) return Task.CompletedTask;

        foreach (var image in images.Select(i => imageFileService.GetFullPath(i, _cancellationTokenSource.Token)))
            _ = TryAdd(image);

        return Task.CompletedTask;
    }

    private async Task TryAdd(Task<PathImageValidObject> image)
    {
        var img = await image;
        Images.TryAdd(img, false);
        OnChangeImg?.Invoke(Images.Select(i => i.Key.LocalPath));
    }

    public async Task BindingImage(object obj, string nameMember, string url)
    {
        var prop = obj.GetType().GetProperty(nameMember);

        try
        {
            _imagePath = await imageFileService.GetFullPath(url, _cancellationTokenSource.Token);
            if (_imagePath is not null) prop.SetValue(obj, _imagePath.LocalPath);
        }
        catch (OperationCanceledException)
        {
        }
        catch (System.Exception ex)
        {
            messageService.Message($"Ошибка загрузки фото: {ex.Message}", TypeMessage.Error);
        }
    }

    public async Task<PathImageValidObject> UpdateImageFromCloudDisk(string imageLocalPath)
    {
        if (_imagePath.LocalPath == imageLocalPath) return _imagePath;

        _ = imageFileService.DeleteImageFromDisk(_imagePath, _cancellationTokenSource.Token);

        return await imageFileService.SaveImageToDick(new PathImageValidObject(imageLocalPath), _cancellationTokenSource.Token);
    }

    private async Task DeleteImagesFromDisk()
    {
        foreach (var kvp in Images.Where(i => i.Value).Select(i => i.Key))
        {
            _ = imageFileService.DeleteImageFromDisk(kvp, _cancellationTokenSource.Token);
            Images.Remove(kvp);
        }
    }

    public async Task<List<string>> UpdateImagesFromCloudDisk()
    {
        _ = DeleteImagesFromDisk();
        List<string> images = new();
        foreach (var pathImageTask in SaveImagesToDisk())
        {
            var pahtImage = await pathImageTask;
            if (pahtImage.CloudPath is null) throw new System.Exception("PathImage обязательно должен иметь CloudPath");
            images.Add(pahtImage.CloudPath);
        }

        return images;
    }

    public Task ClearImages()
    {
        foreach (var kvp in Images.Select(i => i.Key))
        {
            _ = imageFileService.DeleteImageFromDisk(kvp, _cancellationTokenSource.Token);
            Images.Remove(kvp);
        }

        return Task.CompletedTask;
    }
}