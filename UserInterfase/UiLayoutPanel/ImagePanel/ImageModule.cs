using System.Windows.Forms;
using ExtensionFunc;

namespace UserInterface.UiLayoutPanel.ImagePanel;

public class ImageLayoutPanel : FlowLayoutPanel
{
    public ImageLayoutPanel(IRepositoryImgUi context)
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Repository(context);
    }

    public ImageLayoutPanel()
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
    }

    public ImageLayoutPanel Repository(IRepositoryImgUi context)
    {
        context.OnChangeImg += () =>
        {
            Controls.Clear();
            RefreshImages(context);
        };
        RefreshImages(context);
        return this;
    }

    private void RefreshImages(IRepositoryImgUi context) =>
        context.Imgs.ForEach(img => Controls.Add(
            new ImgUi(img.Key)
                .With(i => i.MouseClick += (_, _) => context.ToggleImage(i.Url))));
}