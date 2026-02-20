using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.View.Moduls.DateAttendance;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.DateAttendance.Buttons;

public class DateAttendanceManagmentButton(ControlView controlView, MementoLesson memento) :
    IButtons<ViewButtonClickArgs<DateAttendanceManagment>>
{
    public List<CustomButton>? GetButtons(object? send, ViewButtonClickArgs<DateAttendanceManagment>? eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить")
                .CommandClick(() =>
                {
                    new DateAttendanceAddingUi(memento).ShowDialog();
                    controlView.UpdateGUI();
                }),
        ];
}