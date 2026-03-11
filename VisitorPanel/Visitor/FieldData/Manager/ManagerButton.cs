using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Visitor.FieldData.Manager;

public class ManagerButton(ControlView controlView) : IButtons<Empty>
{
    public List<CustomButton> GetButtons(Empty eventArgs)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(controlView.UpdateGUI)
        ];
}