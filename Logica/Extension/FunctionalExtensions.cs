using static System.Windows.Forms.Control;

public static class FunctionalExtensions
{


    public static T With<T>(this T control, Action<T> action) 
    {
        action?.Invoke(control);
        return control;
    }

    public static T If<T>(this T obj, Func<T, bool> condition, Action<T> action) 
    {
        if (condition.Invoke(obj)) action(obj);
        return obj;
    }

    public static T If<T>(this T obj, bool condition, Action<T> action)
    {
        if (condition) action(obj);
        return obj;
    }
    
    public static T IfElse<T>(this T obj, bool condition, Func<T, T> action, Func<T, T> actionElse)
    {
        if (condition) return action(obj);
        else return actionElse(obj);
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection) action(item);
        return collection;
    }

    public static IEnumerable<Control> AsEnumerable(this ControlCollection controls)
    {
        foreach (Control control in controls)
            yield return control;
    }
}
