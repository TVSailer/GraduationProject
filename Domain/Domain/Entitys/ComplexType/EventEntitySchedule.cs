using System.ComponentModel.DataAnnotations.Schema;
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

    public override string ToString()
    {
        return $"{Date}: {Start}-{End}";
    }
}