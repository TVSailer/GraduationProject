using CSharpFunctionalExtensions;

public static class EntityExtension
{
    public static void SetValue<T>(this T entiy, object? value, string prop)
        where T : Entity
    {
        typeof(T)
        .GetProperty(prop)
        .SetValue(entiy, value);
    }

    public static object? GetValue<T>(this T entity, string prop)
    {
        return typeof(T)
        .GetProperty(prop)
        .GetValue(entity);
    }
}
