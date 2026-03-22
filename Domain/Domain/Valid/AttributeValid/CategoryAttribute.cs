using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class CategoryAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string cat) return false;

        if (string.IsNullOrEmpty(cat))
        {
            ErrorMessage = "Название категории не может быть пустым";
            return false;
        }

        if (cat.Length > 10)
        {
            ErrorMessage = "Название категории не может превышать 10 симмволов";
            return false;
        }

        return true;
    }
}