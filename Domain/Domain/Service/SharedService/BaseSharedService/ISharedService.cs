using CSharpFunctionalExtensions;

namespace Domain.Service.SharedService.BaseSharedService;

public interface ISharedService
{
    public void SetData(object? obj);
    public Maybe<T> GetMaybeData<T>() where T : class; 
    public T GetData<T>() where T : class;
}