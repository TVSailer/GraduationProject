using Domain.Exception;
using Domain.ValidObject.BaseValidObject;

namespace Domain.ValidObject;

public class HttpLinkValidObject : IValidObject
{
    public string Text { get; }

    public HttpLinkValidObject(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) throw new ValidObjectException("URL не может быть пустым");

        if (!Uri.TryCreate(text, UriKind.Absolute, out _)) throw new ValidObjectException("Введите корректный URL");

        Text = text;
    }

    public static HttpLinkValidObject Create(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) throw new ValidObjectException("URL не может быть пустым");

        if (!Uri.TryCreate(text, UriKind.Absolute, out _)) throw new ValidObjectException("Введите корректный URL");

        return new HttpLinkValidObject(text);
    }
}