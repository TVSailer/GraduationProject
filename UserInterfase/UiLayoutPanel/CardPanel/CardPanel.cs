using System.Windows.Forms;
using Extension_Func_Library;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.CardPanel;

public sealed class CardLayoutPanel<T, TCard> : TableLayoutPanel
    where TCard : ObjectCard<T>, new()
{
    private IToolStrip<CardClickedToolStripArgs<T>>? _menuStrip;
    private IClicked<CardClickedArgs<T>>? _onClick;

    public CardLayoutPanel()
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Padding = new Padding(10);
    }
    
    public CardLayoutPanel(T[] entities)
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Padding = new Padding(10);
        Initialize(entities);
    }

    public CardLayoutPanel<T, TCard> Initialize(T[] entities)
    {
        entities
            .With(_ => Controls.Clear()).ForEach(en =>
                Controls.Add(new TCard()
                    .Initialize(this, en)
                    .OnContextMenu(_menuStrip)
                    .OnClickedCard(_onClick)));

        return this;
    }

    public CardLayoutPanel<T, TCard> ClickedCard(IClicked<CardClickedArgs<T>> clicked)
    {
        _onClick = clicked;
        return this;
    }

    public CardLayoutPanel<T, TCard> ContextMenu(IToolStrip<CardClickedToolStripArgs<T>> buttons)
    {
        _menuStrip = buttons;
        return this;
    }
}