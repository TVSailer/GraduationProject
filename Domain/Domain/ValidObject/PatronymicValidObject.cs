using Domain.Exception;

namespace Domain.ValidObject;

public class PatronymicValidObject
{
    public string Text { get; }

    public PatronymicValidObject(string? text)
    {
        if (!string.IsNullOrEmpty(text))
            if (text is { Length: <= 2 } or { Length: > 10 })
                throw new ValidObjectException("Отчество может быть пустым или иметь от 2-х до 10-ти символов");

        Text = text;
    }
}