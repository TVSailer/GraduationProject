using System.Reflection;

public class PropertyMapping
{
    public PropertyInfo ViewModelProperty { get; set; }
    public string EntityPropertyName { get; set; }
    public PropertyInfo EntityProperty { get; set; }
}