namespace Domain.Exception;

public class EnumException(string error) : System.Exception
{
    public override string Message => error;
}