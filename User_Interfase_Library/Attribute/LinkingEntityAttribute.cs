namespace User_Interface_Library.Attribute;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class LinkingEntityAttribute(string nameProperty) : System.Attribute
{
    public string NamePropertyEntity { get; private set; } = nameProperty;
}