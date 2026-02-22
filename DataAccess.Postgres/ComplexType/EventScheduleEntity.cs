using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

[ComplexType]
public class EventScheduleEntity
{
    public TimeOnly Start { get; private set; }
    public TimeOnly End { get; private set; }
    public string Date { get; private set; }

    public EventScheduleEntity()
    {
        
    }

    public EventScheduleEntity(TimeOnly start, TimeOnly end, DateOnly dateTime)
    {
        Start = start;
        End = end;
        Date = dateTime.ToString();
    }

    public DateTime DateT() => DateTime.Parse(Date);

    protected bool Equals(EventScheduleEntity other)
    {
        return Start.Equals(value: other.Start) && End.Equals(value: other.End) && Date == other.Date;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(objA: this, objB: obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals(other: (EventScheduleEntity)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Start.GetHashCode();
            hashCode = (hashCode * 397) ^ End.GetHashCode();
            hashCode = (hashCode * 397) ^ Date.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(EventScheduleEntity? left, EventScheduleEntity? right)
    {
        return Equals(objA: left, objB: right);
    }

    public static bool operator !=(EventScheduleEntity? left, EventScheduleEntity? right)
    {
        return !Equals(objA: left, objB: right);
    }

    public override string ToString()
    {
        return $"{Date}: {Start}-{End}";
    }
}