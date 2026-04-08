using CSharpFunctionalExtensions;
using Domain.Extension;
using System.Text.RegularExpressions;
using Domain.Exception;
using Domain.ValidObject;

namespace Domain.Entitys;

public class VisitorEntity : Entity
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Patronymic { get; private set; }
    public string DateBirth { get; private set; }
    public string NumberPhone { get; private set; }
    public string? Image { get; private set; }
    public AuthEntity AuthEntity { get; private set; }
    public List<LessonEntity> Lessons { get; private set; } = [];
    public List<DateAttendanceEntity> DateAttendances { get; private set; } = [];
    public List<ReviewEntity> Reviews { get; private set; } = [];

    private VisitorEntity() { }

    public VisitorEntity(
        NameValidObject name, 
        SurnameValidObject surname, 
        PatronymicValidObject patronymic, 
        DateBirthVisitorValidObject dateBirth, 
        NumberPhoneValidObject numberPhone, 
        AuthEntity authEntity)
    {
        Name = name.Text;
        Surname = surname.Text;
        Patronymic = patronymic.Text;
        DateBirth = dateBirth.Text;
        NumberPhone = numberPhone.Text;
        AuthEntity = authEntity;
    }
    
    public VisitorEntity(
        ImageValidObject image,
        NameValidObject name, 
        SurnameValidObject surname, 
        PatronymicValidObject patronymic, 
        DateBirthVisitorValidObject dateBirth, 
        NumberPhoneValidObject numberPhone, 
        AuthEntity authEntity)
    {
        Image = image.Text;
        Name = name.Text;
        Surname = surname.Text;
        Patronymic = patronymic.Text;
        DateBirth = dateBirth.Text;
        NumberPhone = numberPhone.Text;
        AuthEntity = authEntity;
    }

    //TODO: delete
    public VisitorEntity(string image, string name, string surname, string patronymic, string dateBirth, string numberPhone, AuthEntity authEntity)
    {
        Image = image;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        DateBirth = dateBirth;
        NumberPhone = numberPhone;
        AuthEntity = authEntity;
    }

    public VisitorEntity UpdateName(NameValidObject name)
    {
        Name = name.Text;
        return this;
    }
    
    public VisitorEntity UpdateSurname(SurnameValidObject surname)
    {
        Surname = surname.Text;
        return this;
    }
    
    public VisitorEntity UpdatePatronymic(PatronymicValidObject patronymic)
    {
        Patronymic = patronymic.Text;
        return this;
    }

    public VisitorEntity UpdateDateBirth(DateBirthVisitorValidObject date)
    {
        DateBirth = date.Text;
        return this;
    }
    
    public VisitorEntity UpdateNumber(NumberPhoneValidObject number)
    {
        NumberPhone = number.Text;
        return this;
    }

    public VisitorEntity UpdateImage(ImageValidObject? image)
    {
        Image = image?.Text;
        return this;
    }

    public Result<VisitorEntity> AddLesson(LessonEntity lesson)
    {
        if (Lessons.Select(l => l.Id).Contains(lesson.Id)) return Result.Failure<VisitorEntity>("Урок с таким же Id уже имеется");
        if (Lessons.Select(l => l.Title).Contains(lesson.Title)) return Result.Failure<VisitorEntity>("Урок с таким же Названием уже имеется");
        Lessons.Add(lesson);

        return this;
    }

    public DateTime GetDateBirth()
    {
        var date = DateBirth.ToDateTime();
        return date.IsFailure ? throw new EntityException("Неверная дата") : date.Value;
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

