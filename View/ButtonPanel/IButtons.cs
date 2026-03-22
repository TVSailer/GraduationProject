using UserInterface.Args;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IButtons<Data>
{
    public InfoButton[] GetButtons(ClickedArgs<Data> eventArgs);
}

