using Domain.Exception;

namespace Domain.ValidObject;

public class CommentValidObject
{
    public string Text { get; }

    private CommentValidObject(string text)
    {
        Text = text;
    }

    public static CommentValidObject Create(string text)
    {
        if (text is { Length: > 200 }) throw new ValidObjectException("Коментарий дожен сожержать до 200 символов");

        var des = text.Split(" ");
        if (des is {Length: < 5}) throw new ValidObjectException("Коментарий дожен состоять минимум из 5-ти слов");

        return new CommentValidObject(text);
    }
}