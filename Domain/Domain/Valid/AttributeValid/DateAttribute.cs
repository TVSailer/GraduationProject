using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class DateAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string date) return false;

        if (string.IsNullOrEmpty(date))
        {
            ErrorMessage = "Значение не может быть пустым";
            return false;
        }

        if (!DateOnly.TryParse(date, out _))
        {
            ErrorMessage = "Значение не соответсвует формату dd/MM/yyyy";
            return false;
        }

        return true;
    }
}