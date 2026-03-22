using Domain.DIService;
using Ninject;

namespace Admin.DI;

public class ServiceProviderDi(StandardKernel container) : IServiceProvision
{
    public T GetService<T>() => (T)GetService(typeof(T));

    public object GetService(Type serviceType)
    {
        return container.Get(serviceType);
    }
}