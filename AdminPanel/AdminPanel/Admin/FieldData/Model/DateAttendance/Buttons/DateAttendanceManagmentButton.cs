using Admin.DI;
using Admin.DI.Module;
using Admin.View.Moduls.DateAttendance;
using DataAccess.Postgres.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.DateAttendance.Buttons;

public class DateAttendanceManagerButton(ControlView controlView, MementoLesson memento) :
    IButtons<DateAttendanceManager>
{
    public List<CustomButton> GetButtons(DateAttendanceManager manager)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить")
                .CommandClick(controlView.ShowDialog<DateAttendanceAddingPanelUi>)
                .Enable(memento.Lesson!.TryRangeScheduleNow()),
        ];
}