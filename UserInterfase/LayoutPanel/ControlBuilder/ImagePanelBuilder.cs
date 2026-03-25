using ExtensionFunc;
using System.Windows.Forms;
using UserInterface.LayoutPanel.ContentSelection;
using UserInterface.Service.Image.BaseServiceImage;
using UserInterface.UiObjects.Image;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ImagePanelBuilder<TParentBuilder> : ControlBuilder<FlowLayoutPanel, TParentBuilder>
{
    public ImagePanelBuilder<TParentBuilder> Setting(
        IImagePanel imagePanel)
    {
        imagePanel.SetAction(imgs =>
        {
            Control.Controls.Clear();
            RefreshImages(imagePanel.ToggleImage, imgs.ToArray());
        });
        RefreshImages(imagePanel.ToggleImage, imagePanel.Images);
        return this;
    }
    
    public ImagePanelBuilder<TParentBuilder> Setting(
        IEnumerable<string>? images,
        Action<string> toggleImage,
        Action<Action<IEnumerable<string>>> setChangeImage)
    {
        setChangeImage.Invoke(imgs =>
        {
            Control.Controls.Clear();
            RefreshImages(toggleImage, imgs.ToArray());
        });

        RefreshImages(toggleImage, images);
        return this;
    }

    private void RefreshImages(Action<string> onToggleImage, IEnumerable<string>? images) =>
        images.ForEach(img => Control.Controls.Add(
            new ImgUi(img)
                .With(i => i.MouseClick += (_, _) => onToggleImage(i.Url))));

    protected override FlowLayoutPanel SettingControl()
    {
        return new FlowLayoutPanel {
            Dock = DockStyle.Fill,
            AutoScroll = true
        };
    }
}