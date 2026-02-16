public interface IServiceProvision : IServiceProvider
{
    public T GetService<T>();
}