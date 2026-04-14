using Domain.Service.ImageService.BaseServiceImage;
using UserInterface.Service.FileDialog.BaseFileDialog;

namespace General.Service.Image;

public class ImageService(IImageDialogService fileDialogImage, IImageSelectionService service) : IImageService
{
    public void OnAddImage() 
        => service.TryAdd(fileDialogImage.ShowOpenFileDialog());
    public void OnDeleteImage()
    {
        if (fileDialogImage.ShowConfirmDialog("Удалить выбранные изображения?"))
            service.Remove(image => image.Value);
    }
    public void ToggleImage(string url) => service.ToggleImage(url);
    public void Binding(object obj, string nameMember) => service.Binding(obj, nameMember);
}