using CSharpFunctionalExtensions;
using Domain.Exception;
using Domain.Extension;

namespace Domain.Entitys;

public class DateAttendanceEntity : Entity
{
    public string Date { get; private set; } = DateTime.Now.ToString(format: "dd/MM/yyyy");
    public LessonEntity Lesson { get; private set; }
    public List<VisitorEntity> Visitors { get; private set; } = [];

    private DateAttendanceEntity() { }

    public DateAttendanceEntity(LessonEntity lesson)
    {
        Lesson = lesson;
    }

    public Result<DateAttendanceEntity> AddVisitor(VisitorEntity visitor)
    {
        if (Visitors.Select(v => v.Id).Contains(visitor.Id)) return Result.Failure<DateAttendanceEntity>("Данный пользователь уже есть");
        Visitors.Add(visitor);
        return Result.Success(this);
    }
    
    public Result<DateAttendanceEntity> AddRangeVisitor(ICollection<VisitorEntity> visitors)
    {
        foreach (var visitorEntity in visitors)
        {
            var result = AddVisitor(visitorEntity);
            if (result.IsFailure) return result;
        }

        return Result.Success(this);
    }

    public string ToString(string date = "")
    {
        if (date.Equals("dd/MM"))
            return DateTime.Parse(Date).ToString("dd/MM");
        return string.IsNullOrEmpty(date) ? Date : throw new EntityException($"неверный формат даты: {date}");
    }

    public DateTime ToDateTime()
    {
        var date = Date.ToDateTime();
        return date.IsFailure ? throw new EntityException("Неверная дата") : date.Value;
    }
}