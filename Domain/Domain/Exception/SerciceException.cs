namespace Domain.Exception;

public class ServiceException(string error) : System.Exception
{
    public override string Message => error;
}