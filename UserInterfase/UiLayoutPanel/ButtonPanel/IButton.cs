using UserInterface.Info;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IClicked<Data>
{
    public InfoButton GetButton(CardClickedArgs<Data> eventArgs);
}