using CSharpFunctionalExtensions;
using Domain.Exception;

namespace Domain.ValidObject;

public class DateBirthTeacherValidObject
{
    public string Text { get; }

    private DateBirthTeacherValidObject(DateOnly text)
    {
        Text = text.ToString();
    }

    public static DateBirthTeacherValidObject Create(DateOnly date)
    {
        if (date.Year > DateTime.Today.Year - 18) throw new ValidObjectException($"Преподователь не может быть младше 18 лет!");
        if (date.Year < DateTime.Today.Year - 100) throw new ValidObjectException("Преподователь не может быть старше 100 лет");

        return new DateBirthTeacherValidObject(date);
    }
}