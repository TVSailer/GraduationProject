using UserInterface.Args;
using UserInterface.Command;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IClicked<Data>
{
    public InfoCommand GetButton(CardClickedArgs<Data> eventArgs);
}