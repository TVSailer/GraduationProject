using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class EstimationAttribute : RequiredAttribute
{
    public EstimationAttribute()
    {
        ErrorMessage = "Не верная оценка";
    }

    public override bool IsValid(object? value)
    {
        if (value is not int estimation) return false;
        if (estimation is > 5 or < 1) return false;
        return true;
    }
}