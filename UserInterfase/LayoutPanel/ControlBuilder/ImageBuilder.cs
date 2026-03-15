using System.Drawing;
using System.Windows.Forms;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ImageBuilder<TParentBuilder> : ControlBuilder<PictureBox, TParentBuilder>
{
    public ImageBuilder<TParentBuilder> Url(string url)
    {
        Control.ImageLocation = url;
        return this;
    }

    protected override PictureBox SettingControl()
    {
        return new PictureBox()
        {
            Anchor = AnchorStyles.None,
            Size = new Size(300, 200),
            Margin = new Padding(5),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.Black,
        };
    }
}