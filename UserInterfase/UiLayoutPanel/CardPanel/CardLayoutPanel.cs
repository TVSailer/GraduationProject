using System.Windows.Forms;
using Extension_Func_Library;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.CardPanel;

public sealed class CardFlowPanel<T, TCard> : FlowLayoutPanel
    where TCard : ObjectCard<T>, new()
{
    private IToolStrip<T>? _menuStrip;
    private IClicked<T>? _onClick;

    public CardFlowPanel()
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Padding = new Padding(10);
    }
    
    public CardFlowPanel(T[] entities)
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Padding = new Padding(10);
        Initialize(entities);
    }

    public CardFlowPanel<T, TCard> Initialize(T[] entities)
    {
        entities
            .With(_ => Controls.Clear()).ForEach(en =>
                Controls.Add(new TCard()
                    .Initialize(this, en)
                    .OnContextMenu(_menuStrip)
                    .OnClickedCard(_onClick)));

        return this;
    }

    public CardFlowPanel<T, TCard> SetClickedCard(IClicked<T> clickeds)
    {
        _onClick = clickeds;
        return this;
    }

    public CardFlowPanel<T, TCard> SetContextMenu(IToolStrip<T> buttons)
    {
        _menuStrip = buttons;
        return this;
    }
}