using Domain.Exception;
using Domain.ValidObject.BaseValidObject;

namespace Domain.ValidObject;

public class TitleValidObject : IValidObject
{
    public string Text { get; }

    public TitleValidObject(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Названиме не может быть пустым");

        if (text.Length > 20) throw new ValidObjectException("Название не может превышать 20 симмволов");

        Text = text;
    }

    public static TitleValidObject Create(string title)
    {
        if (string.IsNullOrEmpty(title)) throw new ValidObjectException("Названиме не может быть пустым");

        if (title.Length > 20) throw new ValidObjectException("Название не может превышать 20 симмволов");

        return new TitleValidObject(title);
    }
}