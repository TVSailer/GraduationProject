using System.Reflection;

namespace ExtensionFunc;

public static class TypeExtension
{
    public static List<TAttribute> GetAttributes<TAttribute>(this Type type)
        where TAttribute : Attribute
    {
        return type.GetProperties()
            .Select(p => p.GetCustomAttribute<TAttribute>())
            .Where(at => at != null)
            .ToList();
    }
}