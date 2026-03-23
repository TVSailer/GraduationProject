using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.DateAttendance.Buttons;

public class DateAttendanceFieldDataButton(ControlView controlView) :
    IButtons<DateAttendanceFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<DateAttendanceFieldData> fieldData)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}