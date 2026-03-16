using DataAccess.PostgreSQL.Models;

namespace DataAccess.PostgreSQL.Logger;

public class EnterLogger(AuthEntity? auth) : ILogger
{
    public readonly AuthEntity? Auth = auth;
    public string Log => Auth is null ? "Неверный логин или пароль" : "";

    public override string ToString() => Log;
}