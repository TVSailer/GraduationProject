using CSharpFunctionalExtensions;

namespace Domain.Entitys;

public class VisitorEntity : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string DateBirth { get; set; }
    public string NumberPhone { get; set; }
    public AuthEntity AuthEntity { get; set; }
    public ICollection<LessonEntity> Lessons { get; set; } = [];
    public ICollection<DateAttendanceEntity> Dates { get; set; } = [];
    public ICollection<ReviewEntity> Reviews { get; set; } = [];

    private VisitorEntity() { }

    public VisitorEntity(string name, string surname, string patronymic, string dateBirth, string numberPhone, AuthEntity authEntity)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        DateBirth = dateBirth;
        NumberPhone = numberPhone;
        AuthEntity = authEntity;
    }

    public override string ToString() => $"{Name} {Surname} {Patronymic}";

    public IEnumerable<string[]> GetLessonWithAttendance()
    {
        foreach (var lesson in Lessons)
        {
            var data = new List<string> { lesson.Title };
            data.AddRange(Dates.Select(date => date.Lesson.Id.Equals(lesson.Id) ? "нб" : ""));
            yield return data.ToArray();
        }
    }
}