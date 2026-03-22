using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class AuthorAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string aut) return false;

        if (string.IsNullOrEmpty(aut))
        {
            ErrorMessage = "Имя автора не может быть пустым";
            return false;
        }

        if (aut.Length > 15)
        {
            ErrorMessage = "Имя автора не может превышать 15 симмволов";
            return false;
        }

        return true;
    }
}