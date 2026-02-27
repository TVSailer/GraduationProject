namespace User_Interface_Library.Interface;

public interface IServiceProvision : IServiceProvider
{
    public T GetService<T>();
}