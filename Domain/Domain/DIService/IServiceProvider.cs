namespace Domain.DIService;

public interface IServiceProvision
{
    public T GetService<T>();
}