using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica.Interface;

namespace Admin.ViewModel.Model.DateAttendance;

public class DateAttendanceFieldData : IFieldData<DateAttendanceEntity>
{
    [LinkingEntity(nameof(DateAttendanceEntity.Date))]
    [ReadOnlyFieldUi("Дата: ")]
    public string Date { get; set; }

    public GenericRepositoryEntity<DateAttendanceEntity> Entity { get; set; } = new();

    public DateAttendanceFieldData()
    {
        Entity.Initialize(this);
    }

}