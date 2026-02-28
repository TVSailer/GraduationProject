namespace UserInterface.UiLayoutPanel.ImagePanel;

public interface IRepositoryImgUi
{
    public event Action? OnChangeImg;
    public Dictionary<string, bool> Imgs { get; protected set; }
    public void ToggleImage(string key);

}
