using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class LocationAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string des) return false;

        if (string.IsNullOrEmpty(des))
        {
            ErrorMessage = "Названиме локации не может быть пустым";
            return false;
        }

        if (des.Length > 20)
        {
            ErrorMessage = "Название локации не может превышать 20 симмволов";
            return false;
        }

        return true;
    }
}