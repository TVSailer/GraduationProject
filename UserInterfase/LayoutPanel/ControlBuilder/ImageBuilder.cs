using ExtensionFunc;
using System.Drawing;
using System.Windows.Forms;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ImageBuilder<TParentBuilder> : ControlBuilder<PictureBox, TParentBuilder>
{
    private const string TitleManager = "Выберите изображение";
    private const string FilesPictureBox = "Выберите изображения PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

    public ImageBuilder<TParentBuilder> Url(string url = "")
    {
        if (string.IsNullOrEmpty(url))
            Control.BackgroundImage = new Bitmap("D://Документы/Projects_CSharp/GraduationProject/UserInterfase/Resource/BaseImage.png");
        Control.ImageLocation = url;
        return this;
    }
    
    public ImageBuilder<TParentBuilder> Binding(object dataSource, string memberName)
    {
        Control.Binding(nameof(PictureBox.ImageLocation), dataSource, memberName);
        MessageErrorProvider(dataSource, memberName);
        return this;
    }

    private void OnAddingImg(object? send, EventArgs eventArgs)
    {
        using var openFileDialog = new OpenFileDialog()
        {
            Filter = FilesPictureBox,
            Title = TitleManager,
            Multiselect = false
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK) return;

        foreach (var fileName in openFileDialog.FileNames)
            Control.ImageLocation = fileName;
    }

    protected override PictureBox SettingControl()
    {
        var pic = new PictureBox
        {
            Anchor = AnchorStyles.None,
            Size = new Size(300, 200),
            Margin = new Padding(5),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.Black,
        };

        pic.DoubleClick += OnAddingImg;

        return pic;
    }
}

