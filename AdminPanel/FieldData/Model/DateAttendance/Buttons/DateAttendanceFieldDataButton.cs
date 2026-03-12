using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.DateAttendance.Buttons;

public class DateAttendanceFieldDataButton(ControlView controlView) :
    IButtons<DateAttendanceFieldData>
{
    public List<InfoButton> GetButtons(DateAttendanceFieldData fieldData)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}