using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class CommentAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string com) return false;

        if (com.Length > 200)
        {
            ErrorMessage = "Коментарий не может превышать 200 симмволов";
            return false;
        }

        var des = com.Split(" ");
        if (des is { Length: < 5 })
        {
            ErrorMessage = "Коментарий дожен состоять минимум из 5-ти слов";
            return false;
        }

        return true;
    }
}