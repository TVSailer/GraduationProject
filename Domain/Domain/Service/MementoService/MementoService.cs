using CSharpFunctionalExtensions;
using Domain.Service.MementoService.BaseMementoService;

namespace Domain.Service.MementoService;

public class MementoService<T> : IMementoService<T>
    where T : class
{
    private T? _memento;

    public void Set(T memento)
    {
        if (memento.Equals(_memento))
            return;

        _memento = memento;
    }

    public Result<T> Get()
    {
        return _memento is null ? 
            Result.Failure<T>("Memento is null") : 
            Result.Success(_memento);
    }
}