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

    public DateAttendanceEntity AddVisitor(VisitorEntity visitor)
    {
        if (Visitors.Select(v => v.Id).Contains(visitor.Id)) throw new EntityException("Данный пользователь уже есть");
        Visitors.Add(visitor);
        return this;
    }
    
    public DateAttendanceEntity AddRangeVisitor(ICollection<VisitorEntity> visitors)
    {
        foreach (var visitorEntity in visitors)
            AddVisitor(visitorEntity);

        return this;
    }
    
    public DateAttendanceEntity UpdateRangeVisitor(ICollection<VisitorEntity> visitors)
    {
        Visitors.Clear();
        foreach (var visitorEntity in visitors)
            AddVisitor(visitorEntity);

        return this;
    }

    public string ToString(string date = "")
    {
        if (date.Equals("dd/MM"))
            return DateTime.Parse(Date).ToString("dd/MM");
        return string.IsNullOrEmpty(date) ? Date : throw new EntityException($"неверный формат даты: {date}");
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not DateAttendanceEntity date) return false;
        return date.Id == Id;
    }

    public DateTime ToDateTime()
    {
        var date = Date.ToDateTime();
        return date.IsFailure ? throw new EntityException("Неверная дата") : date.Value;
    }
}