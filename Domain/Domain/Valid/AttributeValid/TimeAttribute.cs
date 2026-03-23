using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class TimeAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                ErrorMessage = "Значение не может быть пустым";
                return false;
            }

            if (!TimeOnly.TryParse(date, out _))
            {
                ErrorMessage = "Значение не соответсвует формату HH:mm";
                return false;
            }
            return true;
        }
        ErrorMessage = "Значение не может быть пустым";
        return false;
    }
}