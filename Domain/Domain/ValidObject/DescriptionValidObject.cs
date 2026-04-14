using Domain.Exception;

namespace Domain.ValidObject;

public class DescriptionValidObject
{
    public string Text { get; }

    private DescriptionValidObject(string text)
    {
        Text = text;
    }

    public static DescriptionValidObject Create(string text)
    {
        if (text is { Length: > 200 }) throw new ValidObjectException("Описание должно сожержать до 200 символов");

        var des = text.Split(" ");
        if (des is {Length: < 5}) throw new ValidObjectException("Описание должно состоять минимум из 5-ти слов");

        return new DescriptionValidObject(text);
    }
}