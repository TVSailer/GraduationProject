using Domain.Exception;

namespace Domain.ValidObject;

public class ImageValidObject
{
    public string FileName { get; }
    
    public ImageValidObject(string path)
    {
        if (string.IsNullOrEmpty(path)) throw new ValidObjectException("Адресс изображения не может быть пустым");
        if (!(path.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
              path.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
              path.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
              path.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
              path.EndsWith(".png", StringComparison.OrdinalIgnoreCase))) throw new ValidObjectException("Не корректное расширение изображения");

        FileName = path;
    }
}



