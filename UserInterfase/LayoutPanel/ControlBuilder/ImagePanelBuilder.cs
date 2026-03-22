using System.Windows.Forms;
using ExtensionFunc;
using UserInterface.Interfase;
using UserInterface.LayoutPanel.ContentSelection;
using UserInterface.UiLayoutPanel.ImagePanel;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ImagePanelBuilder<TParentBuilder> : ControlBuilder<FlowLayoutPanel, TParentBuilder>
{
    internal ImagePanelBuilder<TParentBuilder> Repository(IRepositoryImgUi context)
    {
        context.OnChangeImg += () =>
        {
            Control.Controls.Clear();
            RefreshImages(context);
        };
        RefreshImages(context);
        return this;
    }

    private void RefreshImages(IRepositoryImgUi context) =>
        context.Imgs.ForEach(img => Control.Controls.Add(
            new ImgUi(img.Key)
                .With(i => i.MouseClick += (_, _) => context.ToggleImage(i.Url))));

    protected override FlowLayoutPanel SettingControl()
    {
        return new FlowLayoutPanel {
            Dock = DockStyle.Fill,
            AutoScroll = true
        };
    }
}