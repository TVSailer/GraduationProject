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

    public Maybe<T> Get()
    {
        return _memento is null ? 
            Maybe<T>.None : Maybe<T>.From(_memento);
    }
}