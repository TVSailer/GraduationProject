namespace DataAccess.PostgreSQL.Logger;

public class EmptyLogger() : ILogger
{
    public string Log => "";
}