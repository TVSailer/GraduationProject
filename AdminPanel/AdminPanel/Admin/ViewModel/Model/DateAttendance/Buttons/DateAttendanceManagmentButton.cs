using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.View.Moduls.DateAttendance;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.DateAttendance.Buttons;

public class DateAttendanceManagmentButton(ControlView controlView, MementoLesson memento) :
    IButtons<ViewButtonClickArgs<DateAttendanceManagment>>
{
    public List<CustomButton>? GetButtons(object? send, ViewButtonClickArgs<DateAttendanceManagment>? eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(controlView.Exit),
            new CustomButton("Добавить")
                .CommandClick(controlView.ShowDialog<DateAttendanceAddingUi>)
                .Enablede(memento.Lesson!.TryRangeScheduleNow()),
        ];
}