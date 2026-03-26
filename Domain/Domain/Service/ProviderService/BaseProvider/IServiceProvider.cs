namespace Domain.Service.ProviderService.BaseProvider;

public interface IServiceProvider
{
    public T GetService<T>();
}