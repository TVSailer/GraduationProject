using CSharpFunctionalExtensions;

namespace Domain.Service.MementoService.BaseMementoService;

public interface IMementoService<T>
    where T : class
{
    public void Set(T memento);
    public Result<T> Get();
}