using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class TitleAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string des)
        {
            if (string.IsNullOrEmpty(des))
            {
                ErrorMessage = "Названиме не может быть пустым";
                return false;
            }

            if (des.Length > 20)
            {
                ErrorMessage = "Название не может превышать 20 симмволов";
                return false;
            }
            return true;
        }

        ErrorMessage = "Названиме не может быть пустым";
        return false;
    }
}