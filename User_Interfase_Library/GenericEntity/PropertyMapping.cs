using System.Reflection;

namespace UserInterface.GenericEntity;

public class PropertyMapping
{
    public PropertyInfo? FieldDataProperty { get; set; }
    public string? EntityPropertyName { get; set; }
    public PropertyInfo? EntityProperty { get; set; }
}