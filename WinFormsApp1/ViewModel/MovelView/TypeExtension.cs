using CSharpFunctionalExtensions;
using System.Data;
using System.Reflection;

public static class TypeExtension
{
    public static List<TAttribute?> GetPropertyInfo<TAttribute>(this Type type)
           where TAttribute : Attribute
    {
        return type.GetProperties()
            .Select(p => p.GetCustomAttribute<TAttribute>())
            .Where(at => at != null)
            .ToList();
    }
}
