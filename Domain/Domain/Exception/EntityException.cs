namespace Domain.Exception;

public class EntityException(string error) : System.Exception
{
    public override string Message => error;
}