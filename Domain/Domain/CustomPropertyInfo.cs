using System.Reflection;

namespace Domain;

public class CustomPropertyInfo<T>(object obj, string nameProp)
{
    public readonly object Obj = obj;
    public readonly PropertyInfo PropertyInfo = obj.GetType().GetProperty(nameProp) ?? throw new NullReferenceException();

    public void SetValue(T value)
        => PropertyInfo.SetValue(Obj, value);

    public T? GetValue() 
        => (T)PropertyInfo.GetValue(Obj);
}