using System.Windows.Forms;
using Extension_Func_Library;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.UiLayoutPanel.CardPanel.Args;

namespace User_Interface_Library.UiLayoutPanel.CardPanel;

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

    public void Initialize(T[] entities)
    {
        entities
            .With(_ => Controls.Clear()).ForEach(en =>
                Controls.Add(new TCard()
                    .Initialize(en)
                    .OnContextMenu(_menuStrip)
                    .OnClickedCard(_onClick)));
    }

    public CardLayoutPanel<T, TCard> SetClickedCard(IButton<CardClickedArgs<T>> buttons) => this.With(_ => _onClick =buttons);
    public CardLayoutPanel<T, TCard> SetContextMenu(IButtons<CardClickedToolStripArgs<T>> buttons) => this.With(_ => _menuStrip = buttons);
}