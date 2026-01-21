using CSharpFunctionalExtensions;
using Logica;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

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
    
    public static bool StartesWith(this string type, string? value)
    {
        if (value is null) return false;
        return type.StartsWith(value);
    }
}
