using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ImageBuilder<TParentBuilder> : ControlBuilder<PictureBox, TParentBuilder>
{
    private const string TitleManager = "Выберите изображение";
    private const string FilesPictureBox = "Выберите изображения PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
    private PropertyInfo? _prop;
    private object? _dataSource;

    public ImageBuilder<TParentBuilder> Url(string url = "")
    {
        var bitmap = new Bitmap("D://Документы/Projects_CSharp/GraduationProject/UserInterfase/Resource/BackgroundImage.png");
        Control.BackgroundImage = bitmap;
        Control.ImageLocation = url;
        return this;
    }
    
    public ImageBuilder<TParentBuilder> ErrorMessage(object dataSource, string memberName)
    {
        MessageErrorProvider(dataSource, memberName);
        return this;
    }
    
    public ImageBuilder<TParentBuilder> Binding(object dataSource, string memberName)
    {
        _prop = dataSource.GetType().GetProperty(memberName);
        _dataSource = dataSource;

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

        Control.ImageLocation = openFileDialog.FileName;
        _prop?.SetValue(_dataSource, openFileDialog.FileName);
    }

    protected override PictureBox SettingControl()
    {
        var pic = new PictureBox
        {
            Anchor = AnchorStyles.None,
            Size = new Size(200, 300),
            Margin = new Padding(5),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.Black,
            BorderStyle = BorderStyle.FixedSingle,
            Dock = DockStyle.Top
        };

        pic.DoubleClick += OnAddingImg;

        return pic;
    }
}

