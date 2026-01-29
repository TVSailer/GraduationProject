using Ninject;

public class ServiceProviderDI(StandardKernel container) : IServiceProvider
{
    private readonly StandardKernel container = container;

    public object? GetService(Type serviceType)
    {
        return container.Get(serviceType);
    }
}