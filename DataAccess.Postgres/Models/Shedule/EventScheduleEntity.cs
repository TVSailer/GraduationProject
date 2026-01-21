using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class EventScheduleEntity : ScheduleEntity
{
    [ForeignKey(nameof(EventEntity))]
    public long EventId { get; private set; }
    public EventEntity Event{ get; private set; }

    public EventScheduleEntity()
    {

    }
        
    public EventScheduleEntity(TimeOnly start, TimeOnly end, Day day) : base(start, end, day)
    {
    }
}