using UserInterface.Info;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IButtons<Data>
{
    public InfoButton[] GetButtons(ClickedArgs<Data> eventArgs);
}

