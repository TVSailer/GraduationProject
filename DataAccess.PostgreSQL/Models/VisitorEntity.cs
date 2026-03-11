using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.PostgreSQL.Models;

public class VisitorEntity : Entity
{
    public FIO FIO { get; set; }
    public string DateBirth { get; set; }
    public string NumberPhone { get; set; }

    [ForeignKey(nameof(AuthEntity))]
    public long AuthId { get; set; }
    public AuthEntity AuthEntity { get; set; }

    public List<LessonEntity> Lessons { get; set; } = [];
    public List<DateAttendanceEntity> Dates { get; set; } = [];
    public List<ReviewEntity> Reviews { get; set; } = [];

    public override string ToString()
    {
        return FIO.ToString();
    }

    public IEnumerable<string[]> GetLessonWithAttendance()
    {
        foreach (var lesson in Lessons)
        {
            var data = new List<string> { lesson.Name };
            data.AddRange(Dates.Select(date => date.Lesson.Id.Equals(lesson.Id) ? "нб" : ""));
            yield return data.ToArray();
        }
    }
}