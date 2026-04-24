using Domain.Exception;

namespace Domain.ValidObject;

public class CategoryValidObject
{
    public string Text { get; }

    public CategoryValidObject(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ValidObjectException("Категория не может быть пустой");

        if (text.Length > 100)
            throw new ValidObjectException("Категория не может быть длиннее 100 символов");

        Text = text;
    }
}