using General.Service.File;

namespace Domain.Service.ImageService.BaseServiceImage;

public interface IImageService
{
    public void UpdateListImages();
    public void AddImage();
    public void ToggleImage(string? path);
    public Task BindingImages(object obj, string nameMember, IEnumerable<string>? images = null);
    public IEnumerable<Task<PathImageValidObject>> SaveImagesToDisk();
    public Task BindingImage(object obj, string nameMember, string url);
    public Task<PathImageValidObject> UpdateImageFromCloudDisk(string imageLocalPath);
    public Task<List<string>> UpdateImagesFromCloudDisk();
    public Task ClearImages();
}