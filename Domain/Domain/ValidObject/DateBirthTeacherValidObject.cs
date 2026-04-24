using CSharpFunctionalExtensions;
using Domain.Exception;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.ValidObject;

public class DateBirthTeacherValidObject
{
    public string Text { get; }

    public DateBirthTeacherValidObject(DateOnly date)
    {
        if (date.Year > DateTime.Today.Year - 18) throw new ValidObjectException($"Преподователь не может быть младше 18 лет!");
        if (date.Year < DateTime.Today.Year - 100) throw new ValidObjectException("Преподователь не может быть старше 100 лет");

        Text = date.ToString("dd.MM.yyyy");
    }
}