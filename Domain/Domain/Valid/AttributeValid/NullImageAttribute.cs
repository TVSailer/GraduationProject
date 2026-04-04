using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class NullImageAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string url)
        {
            if (string.IsNullOrEmpty(url))
                return true;

            if (!(url.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                  url.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                  url.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                  url.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                  url.EndsWith(".png", StringComparison.OrdinalIgnoreCase)))
            {
                ErrorMessage = "Не корректное расширение";
                return false;
            }

            return true;
        }

        ErrorMessage = "Адресс изображения не может быть пустым";
        return false;
    }
}