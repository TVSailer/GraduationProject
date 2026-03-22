using UserInterface.Args;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IToolStrip<Data>
{
    public InfoToolStrip[] GetToolStrip(CardClickedToolStripArgs<Data> eventArgs);
}