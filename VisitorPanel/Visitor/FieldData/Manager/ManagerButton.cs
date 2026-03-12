using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Visitor.FieldData.Manager;

public class ManagerButton(ControlView controlView) : IButtons<EventArgs>
{
    public InfoButton[] GetButtons(EventArgs eventArgs)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(controlView.UpdateGUI)
        ];
}