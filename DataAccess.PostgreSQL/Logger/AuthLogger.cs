namespace DataAccess.PostgreSQL.Logger;

public class AuthLogger(string login, string password) : ILogger
{
    public string Log => $"Логин: {login}\nПароль: {password}";
}