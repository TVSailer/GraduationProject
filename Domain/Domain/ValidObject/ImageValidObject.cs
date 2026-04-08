using Domain.Exception;

namespace Domain.ValidObject;

public class ImageValidObject
{
    public string Text { get; }

    private ImageValidObject(string text)
    {
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