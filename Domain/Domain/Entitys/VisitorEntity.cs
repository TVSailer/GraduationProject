using CSharpFunctionalExtensions;
using Domain.Extension;

namespace Domain.Entitys;

public class VisitorEntity : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string DateBirth { get; set; }
    public string NumberPhone { get; set; }
    public string? Image { get; set; }
    public AuthEntity AuthEntity { get; set; }
    public List<LessonEntity> Lessons { get; set; } = [];
    public List<DateAttendanceEntity> DateAttendances { get; set; } = [];
    public List<ReviewEntity> Reviews { get; set; } = [];

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

    public Result<LessonEntity> AddLesson(LessonEntity lesson)
    {
        if (Lessons.Select(l => l.Id).Contains(lesson.Id)) return Result.Failure<LessonEntity>("Урок с таким же Id уже имеется");
        if (Lessons.Select(l => l.Title).Contains(lesson.Title)) return Result.Failure<LessonEntity>("Урок с таким же Названием уже имеется");
        Lessons.Add(lesson);

        return lesson;
    }

    public DateTime GetDateBirth()
    {
        var date = DateBirth.ToDateTime();
        return date.IsFailure ? throw new Exception("Неверная дата") : date.Value;
    }

    public override string ToString() => $"{Name} {Surname} {Patronymic}";

    public IEnumerable<string[]> GetLessonWithAttendance()
    {
        foreach (var lesson in Lessons)
        {
            var data = new List<string> { lesson.Title };
            data.AddRange(DateAttendances.Select(date => date.Lesson.Id.Equals(lesson.Id) ? "нб" : ""));
            yield return data.ToArray();
        }
    }

    public bool Include(string? name, string? surmane, int? startYear, int? endYear)
    {
        return Name.StartsWith(name ?? "") &&
               Surname.StartsWith(surmane ?? "") &&
               IsBelongingDateBirht(startYear, endYear);
    }

    public bool IsBelongingDateBirht(int? startYear, int? endYear)
    {
        if (startYear is null ||
            endYear is null || 
            startYear == 0 &&
            endYear == 0) return true;

        var nowDate = DateTime.Now;
        var dateBirht = GetDateBirth();

        if (nowDate.Year - dateBirht.Year < startYear) return false;
        if (nowDate.Year - dateBirht.Year > endYear) return false;

        if (IsDateBirth(nowDate.Year - startYear, nowDate, dateBirht)) return false;
        if (IsDateBirth(nowDate.Year - endYear, nowDate, dateBirht)) return false;

        return true;
    }

    private static bool IsDateBirth(int? year, DateTime nowDate, DateTime dateBirht)
    {
        return year == dateBirht.Year &&
               nowDate.Month - dateBirht.Month < 0 &&
               nowDate.Day - dateBirht.Day < 0;
    }
}

