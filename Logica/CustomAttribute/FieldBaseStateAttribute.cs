public class FieldStateAttribute : Attribute
{
    public string Data { get; private set; }

    public FieldStateAttribute(string data)
    {
        Data = data;
    }
}
