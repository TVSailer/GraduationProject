using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class CommentAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string com) return false;

        if (string.IsNullOrEmpty(com))
        {
            ErrorMessage = "Комментраий не может быть пустым";
            return false;
        }

        if (com.Length > 200)
        {
            ErrorMessage = "Коментарий не может превышать 200 симмволов";
            return false;
        }

        return true;
    }
}