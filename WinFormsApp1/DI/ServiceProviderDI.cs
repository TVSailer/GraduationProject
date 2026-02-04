using Ninject;

public class ServiceProviderDI(StandardKernel container) : IServiceProvider
{
    public object GetService(Type serviceType)
    {
        return container.Get(serviceType);
    }
}