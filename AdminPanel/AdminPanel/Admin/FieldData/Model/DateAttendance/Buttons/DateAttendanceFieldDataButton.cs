using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.DateAttendance.Buttons;

public class DateAttendanceFieldDataButton(ControlView controlView) :
    IButtons<DateAttendanceFieldData>
{
    public List<CustomButton> GetButtons(DateAttendanceFieldData fieldData)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
        ];
}