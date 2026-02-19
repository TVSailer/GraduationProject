using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Model.DateAttendance.Buttons;

public class DateAttendanceFieldDataButton(ControlView controlView) :
    IButtons<ViewButtonClickArgs<DateAttendanceEntity, DateAttendanceFieldData>>
{
    public List<CustomButton>? GetButtons(object? send, ViewButtonClickArgs<DateAttendanceEntity, DateAttendanceFieldData>? eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
        ];
}