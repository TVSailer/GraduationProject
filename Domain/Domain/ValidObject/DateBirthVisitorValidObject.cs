using Domain.Exception;

namespace Domain.ValidObject;

public class DateBirthVisitorValidObject
{
    public string Text { get; }

    public DateBirthVisitorValidObject(DateOnly date)
    {
        if (date.Year > DateTime.Today.Year - 18) throw new ValidObjectException($"Посититель не может быть младше 5 лет!");
        if (date.Year < DateTime.Today.Year - 100) throw new ValidObjectException("Посититель не может быть старше 100 лет");

        Text = date.ToString("dd.MM.yyyy");
    }
}