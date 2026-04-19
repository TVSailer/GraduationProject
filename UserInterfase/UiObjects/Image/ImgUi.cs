using ExtensionFunc;
using System.Drawing;
using System.Windows.Forms;

namespace UserInterface.UiObjects.Image;

public sealed class ImgUi : PictureBox
{
    public ImgUi(string url)
    {
        Url = url;
        var orgImage = ScaleImageByHeight(url, 300);

        Size = new Size(orgImage.Width, orgImage.Height);
        Margin = new Padding(5);
        SizeMode = PictureBoxSizeMode.Zoom;
        Image = orgImage;
        MouseDoubleClick += (_, _) => FullSizeImage();
        BackgroundImage =
            new Bitmap("D://Документы/Projects_CSharp/GraduationProject/UserInterfase/Resource/BackgroundImage2.png");
        MouseClick += (_, _) => Image = Image == orgImage ? DarkenImage(orgImage) : orgImage; 
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

    public Bitmap ScaleImageByHeight(string url, int targetHeight)
    {
        using var originalImage = new Bitmap(url);
        double scale = (double)targetHeight / originalImage.Height;
        int targetWidth = (int)(originalImage.Width * scale);

        Bitmap scaledImage = new Bitmap(targetWidth, targetHeight);

        using Graphics g = Graphics.FromImage(scaledImage);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);

        return scaledImage;
    }

    private System.Drawing.Image DarkenImage(System.Drawing.Image original)
    {
        Bitmap result = new Bitmap(original.Width, original.Height);

        using Graphics g = Graphics.FromImage(result);
        g.DrawImage(original, 0, 0, original.Width, original.Height);

        using Brush darkBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
        g.FillRectangle(darkBrush, 0, 0, original.Width, original.Height);

        return result;
    }
}