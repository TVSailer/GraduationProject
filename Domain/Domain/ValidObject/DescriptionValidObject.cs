using Domain.Exception;
using Domain.ValidObject.BaseValidObject;

namespace Domain.ValidObject;

public class DescriptionValidObject : IValidObject
{
    public string Text { get; }

    public DescriptionValidObject(string text)
    {
        if (text is { Length: > 200 }) throw new ValidObjectException("Описание должно сожержать до 200 символов");
        if (text.Split(" ") is { Length: < 5 }) throw new ValidObjectException("Описание должно состоять минимум из 5-ти слов");

        Text = text;
    }
}