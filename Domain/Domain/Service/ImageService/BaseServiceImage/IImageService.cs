using General.Service.File;

namespace Domain.Service.ImageService.BaseServiceImage;

public interface IImageService
{
    public void UpdateListImages();
    public void AddImage();
    public void ToggleImage(string? path);
    public Task BindingImages(object obj, string nameMember, IEnumerable<string>? images = null);
    public IEnumerable<Task<PathImageValidObject>> SaveImagesToDisk();
    public Task BindingImage(object obj, string nameMember, string url = null);
    public Task<PathImageValidObject> UpdateImageFromCloudDisk();
    public Task<List<string>> UpdateImagesFromCloudDisk();
    public Task ClearImages();
    public Task ClearImage();
}