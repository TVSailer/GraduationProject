using ExtensionFunc;
using UserInterface.UiLayoutPanel.ImagePanel;

namespace Visitor.View;

public class RepositoryImage : IRepositoryImgUi
{
    public RepositoryImage(string[] image)
    {
        image.ForEach(i => Imgs.Add(i, false));
    }
    
    public event Action? OnChangeImg;
    public Dictionary<string, bool> Imgs { get; set; } = new();
    public void ToggleImage(string key)
    {
    }
}