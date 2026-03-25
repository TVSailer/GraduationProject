using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;
using ExtensionFunc;
using UserInterface.Command;
using UserInterface.LayoutPanel.ContentSelection;
using UserInterface.UiObjects.Card;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> : ControlBuilder<TControl, TParentBuilder>
    where TControl : Panel, new()
    where TCard : ObjectCard<TEntity>, new()
{
    private InfoCommand[]? _menuStrip;
    private ICommand? _onClick;
    private Func<TEntity[]>? _entities;


    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> SetData(Func<TEntity[]> entities)
    {
        _entities = entities;
        return this;
    }

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> Initialize()
    {
        _entities?.Invoke()
            .With(_ => Control.Controls.Clear()).ForEach(en =>
                Control.Controls.Add(new TCard()
                    .Initialize(this, en)
                    .OnContextMenu(_menuStrip)
                    .OnClickedCard(_onClick)));
        return this;
    }

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> Binding(INotifyPropertyChanged notify)
    {
        notify.PropertyChanged += (_, _) => Initialize();
        return this;
    }

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> ClickedCard(ICommand clicked)
    {
        _onClick = clicked;
        return this;
    }

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> ContextMenu(InfoCommand[] buttons)
    {
        _menuStrip = buttons;
        return this;
    }

    protected override TControl SettingControl()
    {
        return new TControl
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(10),
        };
    }
}