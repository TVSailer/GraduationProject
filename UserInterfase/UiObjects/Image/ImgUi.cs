using ExtensionFunc;
using System.Drawing;
using System.Windows.Forms;

namespace UserInterface.UiObjects.Image;

public sealed class ImgUi : PictureBox
{
    public ImgUi(string url)
    {
        Url = url;

        var width = ScaleWidthByHeight(url, 300);

        Size = new Size(width, 300);
        Margin = new Padding(5);
        SizeMode = PictureBoxSizeMode.Zoom;
        BackColor = Color.Black;
        ImageLocation = url;
        MouseDoubleClick += (_, _) => FullSizeImage();
        BackgroundImage =
            new Bitmap("D://Документы/Projects_CSharp/GraduationProject/UserInterfase/Resource/BackgroundImage2.png");
        MouseClick += (_, _) => BackColor = BackColor == Color.Black ? Color.Gray : Color.Black; 
    }

    public readonly string Url;

    private void FullSizeImage()
    {
        new Form()
            .With(f => f.Text = $@"Просмотр изображения: {Path.GetFileName(Url)}")
            .With(f => f.Size = new Size(800, 600))
            .With(f => f.StartPosition = FormStartPosition.CenterParent)
            .With(f => f.BackColor = Color.Black)
            .With(f => f.Controls.Add(
                new PictureBox()
                    .With(pb => pb.Dock = DockStyle.Fill)
                    .With(pb => pb.SizeMode = PictureBoxSizeMode.Zoom)
                    .With(pb => pb.ImageLocation = Url)))
            .ShowDialog();
    }

    public int ScaleWidthByHeight(string url, int targetHeight)
    {
        var originalImage = new Bitmap(url);
        double scale = (double)targetHeight / originalImage.Height;
        return (int)(originalImage.Width * scale);
    }
}