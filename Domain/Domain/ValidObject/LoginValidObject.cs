using Domain.Exception;

namespace Domain.ValidObject;

public class LoginValidObject
{
    public string Login { get; }

    private LoginValidObject(string login)
    {
        Login = login;
    }

    public static LoginValidObject Create(string text)
    {
        if (string.IsNullOrEmpty(text)) throw new ValidObjectException("Логин не может быть пустым");
        if (text is { Length: <= 2 } or { Length: > 20 }) throw new ValidObjectException("Кол-во символом должно быть в от 2 до 20");

        var random = new Random();

        return new LoginValidObject(text + random.Next(10000));
    }
}