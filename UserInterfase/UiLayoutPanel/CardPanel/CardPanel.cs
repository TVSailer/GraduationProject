using System.Windows.Forms;
using Extension_Func_Library;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.CardPanel;

public sealed class CardPanel<T, TCard> : TableLayoutPanel
    where TCard : ObjectCard<T>, new()
{
    private IButtons<CardClickedToolStripArgs<T>>? _menuStrip;
    private IButton<CardClickedArgs<T>>? _onClick;

    public CardPanel()
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Padding = new Padding(10);
    }

    public CardPanel<T, TCard> Initialize(T[] entities)
    {
        entities
            .With(_ => Controls.Clear()).ForEach(en =>
                Controls.Add(new TCard()
                    .Initialize(this, en)
                    .OnContextMenu(_menuStrip)
                    .OnClickedCard(_onClick)));

        return this;
    }

    public CardPanel<T, TCard> SetClickedCard(IButton<CardClickedArgs<T>> button)
    {
        _onClick = button;
        return this;
    }

    public CardPanel<T, TCard> SetContextMenu(IButtons<CardClickedToolStripArgs<T>> buttons)
    {
        _menuStrip = buttons;
        return this;
    }
}