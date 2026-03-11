using System.Windows.Forms;
using Extension_Func_Library;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.CardPanel;

public sealed class CardLayoutPanel<T, TCard> : FlowLayoutPanel
    where TCard : ObjectCard<T>, new()
{
    private IButtons<CardClickedToolStripArgs<T>>? _menuStrip;
    private IButton<CardClickedArgs<T>>? _onClick;

    public CardLayoutPanel()
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Padding = new Padding(10);
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

    public CardLayoutPanel<T, TCard> SetClickedCard(IButton<CardClickedArgs<T>> buttons)
    {
        _onClick = buttons;
        return this;
    }

    public CardLayoutPanel<T, TCard> SetContextMenu(IButtons<CardClickedToolStripArgs<T>> buttons)
    {
        _menuStrip = buttons;
        return this;
    }
}