using Domain.Exception;

namespace Domain.ValidObject;

public class TitleValidAttribute
{
    public string Text { get; }

    private TitleValidAttribute(string text)
    {
        Text = text;
    }

    public TitleValidAttribute Create(string title)
    {
        if (string.IsNullOrEmpty(title)) throw new ValidObjectException("Названиме не может быть пустым");

        if (title.Length > 20) throw new ValidObjectException("Название не может превышать 20 симмволов");

        return new TitleValidAttribute(title);
    }
}