using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class UrlAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string des)
        {
            if (string.IsNullOrEmpty(des))
            {
                ErrorMessage = "Url-адресс не может быть пустым";
                return false;
            }

            if (!Uri.TryCreate(des, UriKind.Absolute, out _))
            {
                ErrorMessage = "Не корректный url-адресс";
                return false;
            }

            return true;
        }
        ErrorMessage = "Url-адресс не может быть пустым";
        return false;
    }
}