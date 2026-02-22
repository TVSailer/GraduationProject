namespace Logica.CustomAttribute;

public class FieldStateAttribute(string data) : Attribute
{
    public string Data { get; private set; } = data;
}