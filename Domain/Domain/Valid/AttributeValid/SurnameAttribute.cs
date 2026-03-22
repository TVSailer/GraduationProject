using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class SurnameAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ErrorMessage = "Фамилия не может быть пустым";
                return false;
            }

            if (name.Length is < 2 or > 10)
            {
                ErrorMessage = "Фамилия может иметь от 2-х до 10-ти символов";
                return false;
            }
        }

        return false;
    }
}