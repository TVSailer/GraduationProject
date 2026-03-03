namespace DataAccess.Postgres;

public class RepositoryLogger(string info) : ILogger
{
    public string Log => info;
}