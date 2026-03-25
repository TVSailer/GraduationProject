namespace General.Service.ProvisionUI;

public interface IServiceProvider
{
    public T GetService<T>();
}