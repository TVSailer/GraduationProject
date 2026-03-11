using System.Reflection;

namespace UserInterface.GenericEntity;

public class PropertyMapping
{
    public PropertyMapping(PropertyInfo? fieldDataProperty, string? entityPropertyName, PropertyInfo? entityProperty)
    {
        FieldDataProperty = fieldDataProperty;
        EntityPropertyName = entityPropertyName;
        EntityProperty = entityProperty;
    }

    public PropertyInfo? FieldDataProperty { get; set; }
    public string? EntityPropertyName { get; set; }
    public PropertyInfo? EntityProperty { get; set; }
}