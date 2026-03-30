using ExtensionFunc;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;
using UserInterface.LayoutPanel.ContentSelection;
using UserInterface.Service.Image.BaseServiceImage;
using UserInterface.UiObjects.Image;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ImagePanelBuilder<TParentBuilder> : ControlBuilder<FlowLayoutPanel, TParentBuilder>
{
    private ICommand? _command;

    public ImagePanelBuilder<TParentBuilder> Setting(
        IImagePanel imagePanel)
    {
        imagePanel.SetAction(imgs =>
        {
            Control.Controls.Clear();
            RefreshImages(imgs);
        });
        RefreshImages(imagePanel.Images);
        return this;
    }

    public ImagePanelBuilder<TParentBuilder> Command(ICommand toggleImage)
    {
        _command = toggleImage;
        return this;
    }

    public ImagePanelBuilder<TParentBuilder> Binding(object bind, string nameMember)
    {
        if (bind is INotifyPropertyChanged notifyPropertyChanged)
        {
            notifyPropertyChanged.PropertyChanged += (s, e) =>
            {
                if (!e.PropertyName.Equals(nameMember)) return;
                Initialize(bind, nameMember, true);
            };

            Initialize(bind, nameMember);
        }
        return this;
    }

    private void Initialize(object bind, string nameMember, bool isClear = false)
    {
        var prop = bind.GetType().GetProperty(nameMember);

        if (isClear) Control.Controls.Clear();

        var images = (IEnumerable<string>)prop.GetValue(bind);
        RefreshImages(images);
    }

    private void RefreshImages(IEnumerable<string>? images) =>
        images.ForEach(img => Control.Controls.Add(
            new ImgUi(img)
                .With(i => i.MouseClick += (_, _) =>
                {
                    if (_command is null) return;
                    if (_command.CanExecute(i.Url))
                        _command.Execute(i.Url);
                })));

    protected override FlowLayoutPanel SettingControl()
    {
        return new FlowLayoutPanel {
            Dock = DockStyle.Fill,
            AutoScroll = true
        };
    }
}