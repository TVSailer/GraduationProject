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
    private List<InfoCommand> _menuStrip = [];
    private ICommand? _onClick;
    private Func<IEnumerable<TEntity>>? _entities;

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> Initialize(IEnumerable<TEntity> entities)
    {
        entities.With(_ => Control.Controls.Clear()).ForEach(en =>
                Control.Controls.Add(new TCard()
                    .Initialize(this, en)
                    .OnContextMenu(_menuStrip.ToArray())
                    .OnClickedCard(_onClick)));
        return this;
    }

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> Binding(object notify, string nameMember)
    {
        if (notify is INotifyPropertyChanged notifyPropertyChanged)
        {
            notifyPropertyChanged.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName!.Equals(nameMember)) InitializeData(notifyPropertyChanged, nameMember);
            };

            InitializeData(notifyPropertyChanged, nameMember);
        }
        return this;
    }

    private void InitializeData(INotifyPropertyChanged notify, string nameMember)
    {
        var prop = notify.GetType().GetProperty(nameMember);
        var data = (IEnumerable<TEntity>)prop.GetValue(notify);

        Initialize(data);
    }


    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> ClickedCard(ICommand clicked)
    {
        _onClick = clicked;
        return this;
    }

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> ContextMenu(string name, ICommand command)
    {
        _menuStrip.Add(new InfoCommand(name, command));
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