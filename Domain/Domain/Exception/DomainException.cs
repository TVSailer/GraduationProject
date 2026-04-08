namespace Domain.Exception;

public class ValidObjectException(string error) : System.Exception
{
    public override string Message => error;
}