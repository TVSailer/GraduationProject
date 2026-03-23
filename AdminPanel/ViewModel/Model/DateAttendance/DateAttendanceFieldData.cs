using DataAccess.PostgreSQL.ModelsPrimitive;
using UserInterface.Attribute;
using UserInterface.Interface;

namespace Admin.FieldData.Model.DateAttendance;

public class DateAttendanceFieldData : IDataUi<DateAttendanceEntity>
{
    [LinkingEntity(nameof(DateAttendanceEntity.Date))]
    public string? Date { get; set; }

    public DateAttendanceEntity Entity { get; set; }
    public long EntityId { get; set; }
}