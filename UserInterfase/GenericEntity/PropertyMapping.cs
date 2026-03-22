using System.Reflection;

namespace UserInterface.GenericEntity;

public class PropertyMapping(PropertyInfo? fieldDataProperty, string? entityPropertyName, PropertyInfo? entityProperty)
{
    public PropertyInfo? FieldDataProperty { get; set; } = fieldDataProperty;
    public string? EntityPropertyName { get; set; } = entityPropertyName;
    public PropertyInfo? EntityProperty { get; set; } = entityProperty;
}