using System.Windows.Forms;
using Extension_Func_Library;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> : ControlBuilder<TControl, TParentBuilder>
    where TControl : Panel, new()
    where TCard : ObjectCard<TEntity>, new()
{
    private IToolStrip<CardClickedToolStripArgs<TEntity>>? _menuStrip;
    private IClicked<CardClickedArgs<TEntity>>? _onClick;

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> Initialize(TEntity[] entities)
    {
        entities
            .With(_ => Control.Controls.Clear()).ForEach(en =>
                Control.Controls.Add(new TCard()
                    .Initialize(this, en)
                    .OnContextMenu(_menuStrip)
                    .OnClickedCard(_onClick)));

        return this;
    }

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> ClickedCard(IClicked<CardClickedArgs<TEntity>> clicked)
    {
        _onClick = clicked;
        return this;
    }

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> ContextMenu(IToolStrip<CardClickedToolStripArgs<TEntity>> buttons)
    {
        _menuStrip = buttons;
        return this;
    }

    protected override TControl SettingControl()
    {
        return new TControl()
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(10),
        };
    }
}