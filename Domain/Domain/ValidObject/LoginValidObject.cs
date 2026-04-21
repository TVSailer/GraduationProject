using Domain.Exception;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.ValidObject;

public class LoginValidObject
{
    public string Login { get; }

    public LoginValidObject(string login)
    {
        if (string.IsNullOrEmpty(login)) throw new ValidObjectException("Логин не может быть пустым");
        if (login is { Length: <= 2 } or { Length: > 20 }) throw new ValidObjectException("Кол-во символом должно быть в от 2 до 20");

        var random = new Random();

        Login = login + random.Next(10000);
    }

    public static LoginValidObject Create(string text)
    {
        return new LoginValidObject(text);
    }
}