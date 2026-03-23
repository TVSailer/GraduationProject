using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class DateAttribute : RequiredAttribute
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

            if (!DateOnly.TryParse(date, out _))
            {
                ErrorMessage = "Значение не соответсвует формату dd/MM/yyyy";
                return false;
            }

            return true;
        }
        ErrorMessage = "Значение не может быть пустым";
        return false;
    }
}