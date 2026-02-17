using Ninject;

public class ServiceProviderDI(StandardKernel container) : IServiceProvision
{
    public T GetService<T>() => (T)GetService(typeof(T));

    public object GetService(Type serviceType)
    {
        return container.Get(serviceType);
    }
}