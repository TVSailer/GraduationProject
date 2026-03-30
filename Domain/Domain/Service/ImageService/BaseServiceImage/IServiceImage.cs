namespace Domain.Service.ImageService.BaseServiceImage;

public interface IImageService
{
    public void OnDeleteImage();
    public void OnAddImage();
    public void ToggleImage(string? url);
    public void Binding(object obj, string nameMember);
}