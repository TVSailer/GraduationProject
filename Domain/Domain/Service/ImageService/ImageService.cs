using Domain.Enum;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;

namespace Domain.Service.ImageService;

public class ImageService(IMessageService messageService,  IImageFileService imageFileService) : IImageService
{
    public event Action<IEnumerable<string>>? OnChangeImg;
    public readonly Dictionary<string, bool> Images = [];

    public void OnAddImage()
        => TryAdd(imageFileService.ShowOpenFileDialog());

    public void OnDeleteImage()
    { if (messageService.Message("Удалить выбранные изображения?", TypeMessage.YesNo) == TypeCommandMessage.Yes) Remove(); }

    public IEnumerable<string> SaveImagesToDisk() 
        => imageFileService.SaveImagesToDisk(Images.Select(i => i.Key));

    public void ToggleImage(string key)
        => Images[key] = !Images[key];

    public void TryAdd(IEnumerable<string>? urls)
    {
        if (urls is null) return;

        foreach (var url in urls.Select(imageFileService.GetFullPath))
            Images.TryAdd(url, false);
        OnChangeImg?.Invoke(Images.Select(i => i.Key));
    }

    private void Remove()
    {
        if (!Images.Any(kvp => kvp.Value)) return;

        foreach (var kvp in Images.Where(i => i.Value))
        {
            imageFileService.DeleteImageFromDisk(kvp.Key);
            Images.Remove(kvp.Key);
        }

        OnChangeImg?.Invoke(Images.Select(i => i.Key));
    }

    public void Binding(object obj, string nameMember)
    {
        var prop = obj.GetType().GetProperty(nameMember);
        TryAdd((IEnumerable<string>)prop.GetValue(obj));
        OnChangeImg += images => prop.SetValue(obj, images);
    }
}