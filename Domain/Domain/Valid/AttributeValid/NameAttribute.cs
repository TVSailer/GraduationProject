using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class NameAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ErrorMessage = "Имя не может быть пустым";
                return false;
            }

            if (name is {Length: < 2} or { Length: > 10 })
            {
                ErrorMessage = "Имя может иметь от 2-х до 10-ти символов";
                return false;
            }

            return true;
        }

        return false;
    }
}