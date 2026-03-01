namespace DataAccess.Postgres;

public class AuthLogger(string login, string password) : ILogger
{
    public string Log => $"Логин: {login}\nПароль: {password}";
}