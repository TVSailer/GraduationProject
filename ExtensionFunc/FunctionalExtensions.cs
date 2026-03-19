using System.Collections;

namespace ExtensionFunc;

public static class FunctionalExtensions
{
    public static T With<T>(this T control, Action<T> action) 
    {
        action?.Invoke(control);
        return control;
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        if (collection is null) return collection;
        foreach (var item in collection) action(item);
        return collection;
    }
    
    public static IEnumerable ForEach(this IEnumerable collection, Action<object> action)
    {
        foreach (var item in collection) action(item);
        return collection;
    }
}