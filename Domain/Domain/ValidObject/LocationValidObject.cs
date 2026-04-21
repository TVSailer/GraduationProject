using Domain.Exception;
using Domain.ValidObject.BaseValidObject;

namespace Domain.ValidObject;

public class LocationValidObject : IValidObject
{
    public string Text { get; }

    public LocationValidObject(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Название локации не может быть пустым");
        if (text.Length > 20) throw new ValidObjectException("Название локации не может превышать 20 символов");

        Text = text;
    }

    public static LocationValidObject Create(string text)
    {

        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Название локации не может быть пустым");

        if (text.Length > 20) throw new ValidObjectException("Название локации не может превышать 20 символов");

        return new LocationValidObject(text);
    }
}