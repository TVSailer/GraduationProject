using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.FieldData.Visitor.Button;

public class VisitorButtons(ControlView controlView) : IButtons<VisitorPanelUi>
{
    public InfoButton[] GetButtons(ClickedArgs<VisitorPanelUi> eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}