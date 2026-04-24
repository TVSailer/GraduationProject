using Domain.Exception;

namespace Domain.ValidObject;

public class NameValidObject
{
    public string Text { get; }

    public NameValidObject(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Имя не может быть пустым");
        if (text is { Length: <= 2 } or { Length: > 10 }) throw new ValidObjectException("Имя может иметь от 2-х до 10-ти символов");

        Text = text;
    }
}