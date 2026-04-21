using System.ComponentModel.DataAnnotations.Schema;
using Domain.Exception;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ComplexType;

[ComplexType]
public class EventEntitySchedule
{
    [Time] public string Start { get; set; }
    [Time] public string End { get; set; }
    [Date] public string Date { get; set; }

    private EventEntitySchedule() { }

    public EventEntitySchedule(string start, string end, string date)
    {
        Start = start;
        End = end;
        Date = date;
    }
    
    public EventEntitySchedule(TimeOnly start, TimeOnly end, DateOnly date)
    {
        if (start > end) throw new EntityException("Время начало не может быть позже конца");

        if (date.Year - DateTime.Now.Year > 5) throw new EntityException("Мероприя не можеть быть запланировано на 5 лет вперед");

        Start = start.ToString();
        End = end.ToString();
        Date = date.ToString("dd.MM.yyyy");
    }

    public override string ToString()
    {
        return $"{Date}: {Start}-{End}";
    }
}