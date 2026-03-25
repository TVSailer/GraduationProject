using Ninject;
using UserInterface.DIService;

namespace General.Service.ProvisionUI;

public class ServiceProviderUI(StandardKernel container) : IServiceProvisionUI, IServiceProvider
{
    public T GetService<T>() => (T)GetService(typeof(T));

    public object GetService(Type serviceType)
    {
        return container.Get(serviceType);
    }
}