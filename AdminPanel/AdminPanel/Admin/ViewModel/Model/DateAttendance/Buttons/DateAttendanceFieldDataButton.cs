using Admin.Args;
using Admin.View;
using DataAccess.Postgres.Models;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.DateAttendance.Buttons;

public class DateAttendanceFieldDataButton(ControlView controlView) :
    IButtons<ViewButtonClickArgs<DateAttendanceEntity, DateAttendanceFieldData>>
{
    public List<CustomButton> GetButtons(object? send, ViewButtonClickArgs<DateAttendanceEntity, DateAttendanceFieldData>? eventArgs)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
        ];
}