namespace DataAccess.PostgreSQL.Logger;

public class RepositoryLogger(string info) : ILogger
{
    public string Log => info;
}