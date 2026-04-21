using Domain.Exception;
using Domain.ValidObject.BaseValidObject;

namespace Domain.ValidObject;

public class OrganizerValidObject : IValidObject
{
    public string Text { get; }

    public OrganizerValidObject(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Название организации не может быть пустым");

        if (text.Length > 20) throw new ValidObjectException("Название организации не может превышать 20 символов");

        Text = text;
    }

    public static OrganizerValidObject Create(string text)
    {

        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Имя организатора не может быть пустым");

        if (text.Length > 20) throw new ValidObjectException("Имя организатора не может превышать 20 символов");

        return new OrganizerValidObject(text);
    }
}