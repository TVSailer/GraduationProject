using System.Drawing;
using System.Windows.Forms;
using ExtensionFunc;

namespace UserInterface.UiLayoutPanel.ImagePanel;

public sealed class ImgUi : PictureBox
{
    public ImgUi(string url)
    {
        Url = url;

        Size = new Size(300, 200);
        Margin = new Padding(5);
        SizeMode = PictureBoxSizeMode.Zoom;
        BackColor = Color.Black;
        ImageLocation = url;
        MouseDoubleClick += (_, _) => FullSizeImage();
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
}