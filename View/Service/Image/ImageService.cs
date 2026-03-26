using Domain.Service.Image.BaseServiceImage;
using Domain.Service.ImageService.BaseServiceImage;
using UserInterface.Service.FileDialog.BaseFileDialog;

namespace General.Service.Image;

public class ImageService(IImageDialogService fileDialogImage, IImageSelectionService service) : IImageService
{
    public void OnAddImage() => service.TryAdd(fileDialogImage.ShowOpenFileDialog());
    public void TryAdd(IEnumerable<string> urls) => service.TryAdd(urls);

    public void OnDeleteImage()
    {
        if (fileDialogImage.ShowConfirmDialog("Удалить выбранные изображения?"))
            service.Remove(image => image.Value);
    }
    public Action<string> ToggleImage() => service.ToggleImage;
    public IEnumerable<string>? GetImages() => service.Get();
    public void SetAction(Action<IEnumerable<string>> changeImage) => service.OnChangeImg += changeImage;
}