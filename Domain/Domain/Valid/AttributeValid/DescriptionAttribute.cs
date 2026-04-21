using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class DescriptionAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string des)
        {
            if (string.IsNullOrEmpty(des))
            {
                ErrorMessage = "Описание не может быть пустым";
                return false;
            }

            if (des.Split(" ") is { Length: < 5 })
            {
                ErrorMessage = "Описание должно состоять минимум из 5-ти слов";
                return false;
            }

            if (des.Length > 200)
            {
                ErrorMessage = "Описание не может превышать 200 симмволов";
                return false;
            }

            return true;
        }
        ErrorMessage = "Описание не может быть пустым";
        return false;
    }
}