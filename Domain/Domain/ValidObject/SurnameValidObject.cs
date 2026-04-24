using Domain.Exception;

namespace Domain.ValidObject;

public class SurnameValidObject
{
    public string Text { get; }

    public SurnameValidObject(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Фамилия не может быть пустым");
        if (text is { Length: <= 2 } or { Length: > 10 }) throw new ValidObjectException("Фамилия может иметь от 2-х до 10-ти символов");

        Text = text;
    }
}

