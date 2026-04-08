using Domain.Exception;

namespace Domain.ValidObject;

public class SurnameValidObject
{
    public string Text { get; }

    private SurnameValidObject(string text)
    {
        Text = text;
    }

    public static SurnameValidObject Create(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Фамилия не может быть пустым");
        if (text is { Length: <= 2 } or { Length: > 10 }) throw new ValidObjectException("Фамилия может иметь от 2-х до 10-ти символов");

        return new SurnameValidObject(text);
    }
}

