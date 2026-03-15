using UserInterface.Info;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IButtons<in Data>
{
    public InfoButton[] GetButtons(ClickedArgs<Data> eventArgs);
}

