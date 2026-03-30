using CSharpFunctionalExtensions;
using Domain.Service.SharedService.BaseSharedService;

namespace Domain.Service.SharedService;

public class SharedService : ISharedService
{
    private object? _data;

    public void SetData(object? obj) => _data = obj;
    public Maybe<T> GetMaybeData<T>() where T : class
    {
        if (_data is null) return Maybe<T>.None;
        if (_data is not T) throw new Exception($"Object is not {typeof(T)}");

        var data = Clear<T>();

        return Maybe<T>.From(() => data);
    }

    public T GetData<T>() where T : class
    {
        if (_data is null) throw new Exception($"Object is null");
        if (_data is not T) throw new Exception($"Object is not {typeof(T)}");

        var data = Clear<T>();

        return data;
    }

    private T Clear<T>()
    {
        var data = _data;
        _data = null;
        return (T)data;
    }
}