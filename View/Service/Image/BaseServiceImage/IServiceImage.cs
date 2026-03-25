namespace General.Service.Image.BaseServiceImage;

public interface IServiceImage
{
    public void TryAdd(IEnumerable<string> urls);
    public void OnDeleteImage();
    public void OnAddImage();
    public IEnumerable<string> GetImages();
    public Action<string> ToggleImage();
    public void SetAction(Action<IEnumerable<string>> changeImage);
}