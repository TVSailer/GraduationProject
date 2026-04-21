using Domain.Exception;
using Domain.ValidObject.BaseValidObject;

namespace Domain.ValidObject;

public class ImageValidObject : IValidObject
{
    public string Text { get; }

    public ImageValidObject(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Адресс изображения не может быть пустым");
        if (!(text.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
              text.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
              text.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
              text.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
              text.EndsWith(".png", StringComparison.OrdinalIgnoreCase))) throw new ValidObjectException("Не корректное расширение изображения");

        Text = text;
    }

    public static ImageValidObject Create(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Адресс изображения не может быть пустым");
        if (!(text.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
              text.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
              text.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
              text.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
              text.EndsWith(".png", StringComparison.OrdinalIgnoreCase))) throw new ValidObjectException("Не корректное расширение изображения");

        return new ImageValidObject(text);
    }
}

