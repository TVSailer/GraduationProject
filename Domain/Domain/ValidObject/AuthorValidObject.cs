using Domain.Exception;
using Domain.ValidObject.BaseValidObject;

namespace Domain.ValidObject;

public class AuthorValidObject : IValidObject
{
    public string Text { get; }

    public AuthorValidObject(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Имя автора не может быть пустым");

        if (text.Length > 20) throw new ValidObjectException("Имя автора не может превышать 20 символов");

        Text = text;
    }
}