using System.Windows.Forms;
using ExtensionFunc;
using UserInterface.Interfase;

namespace UserInterface.GenericEntity;

public class RepositoryImgEntity : IRepositoryImg, IRepositoryImgUi
{
    private const string TitleManager = "Выберите изображения мероприятия";
    private const string FilesPictureBox = "Выберите изображения PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

    public event Action? OnChangeImg;
    public Dictionary<string, bool> Imgs { get; set; } = [];

    public string[] GetData() 
        => Imgs.Select(img => img.Key ).ToArray();
    public void SetData(string[] list)
    {
        list.ForEach(img => Imgs.Add(img, false));
        OnChangeImg?.Invoke();
    }

    public void OnAddingImg()
    {
        using var openFileDialog = new OpenFileDialog()
        {
            Filter = FilesPictureBox,
            Title = TitleManager,
            Multiselect = true
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK) return;

        foreach (var fileName in openFileDialog.FileNames)
            Imgs.TryAdd(fileName, false);

        OnChangeImg?.Invoke();
    }

    public void OnDeletingImg()
    {
        Imgs.ForEach(img => { if (img.Value) Imgs.Remove(img.Key); });
        OnChangeImg?.Invoke();
    }

    public void ToggleImage(string key)
    {
        Imgs[key] = !Imgs[key];
    }
}