using CSharpFunctionalExtensions;
using Domain.Exception;

namespace Domain.ValidObject;

public class DateBirthVisitorValidObject
{
    public string Text { get; }

    private DateBirthVisitorValidObject(DateOnly text)
    {
        Text = text.ToString();
    }

    public static DateBirthVisitorValidObject Create(DateOnly date)
    {
        if (date.Year > DateTime.Today.Year - 18) throw new ValidObjectException($"Посититель не может быть младше 5 лет!");
        if (date.Year < DateTime.Today.Year - 100) throw new ValidObjectException("Посититель не может быть старше 100 лет");

        return new DateBirthVisitorValidObject(date);
    }
}