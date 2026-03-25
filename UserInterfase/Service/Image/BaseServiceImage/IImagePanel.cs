namespace UserInterface.Service.Image.BaseServiceImage;

public interface IImagePanel
{
    public Action<string> ToggleImage { get; protected set; }
    IEnumerable<string>? Images { get; protected set; }
    public void SetAction(Action<IEnumerable<string>> changeImage);
}