using System.Windows.Forms;
using Extension_Func_Library;

namespace User_Interface_Library.UiLayoutPanel.ImagePanel;

public class ImageLayoutPanel : FlowLayoutPanel
{
    public ImageLayoutPanel(IRepositoryImgUi context)
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;

        context.OnChangeImg += () =>
        {
            Controls.Clear();
            RefreshImages(context);
        };
        RefreshImages(context);
    }

    private void RefreshImages(IRepositoryImgUi context) =>
        context.Imgs.ForEach(img => Controls.Add(
            new ImgUi(img.Key)
                .With(i => i.MouseClick += (_, _) => context.ToggleImage(i.Url))));
}