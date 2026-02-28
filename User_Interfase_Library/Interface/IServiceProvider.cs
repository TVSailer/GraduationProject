namespace UserInterface.Interface;

public interface IServiceProvision
{
    public T GetService<T>();
}