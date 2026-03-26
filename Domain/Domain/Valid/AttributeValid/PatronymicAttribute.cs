using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class PatronymicAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string name)
        {
            if (string.IsNullOrEmpty(name)) return true;

            if (name is { Length: < 2 } or { Length: > 10 })
            {
                ErrorMessage = "Отчество может быть пустым или иметь от 2-х до 10-ти символов";
                return false;
            }

            return true;
        }

        return false;
    }
}