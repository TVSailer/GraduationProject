using System.ComponentModel.DataAnnotations.Schema;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ComplexType;

[ComplexType]
public class EventSchedule(string? start, string? end, string? date)
{
    [Time] public string Start { get; set; } = start;
    [Time] public string End { get; set; } = end;
    [Date] public string Date { get; set; } = date;

    public override string ToString()
    {
        return $"{Date}: {Start}-{End}";
    }
}