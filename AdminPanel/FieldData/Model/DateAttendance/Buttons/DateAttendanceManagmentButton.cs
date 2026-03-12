using Admin.DI;
using Admin.DI.Module;
using Admin.View.Moduls.DateAttendance;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.DateAttendance.Buttons;

public class DateAttendanceManagerButton(ControlView controlView, MementoLesson memento) :
    IButtons<DateAttendanceManager>
{
    public List<InfoButton> GetButtons(DateAttendanceManager manager)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить")
                .CommandClick(controlView.ShowDialog<DateAttendanceAddingPanelUi>)
                .Enable(memento.Lesson!.TryRangeScheduleNow()),
        ];
}