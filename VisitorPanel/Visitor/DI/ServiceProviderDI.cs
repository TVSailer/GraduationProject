using Ninject;
using UserInterface.DIService;
using IServiceProvider = Domain.Service.ProviderService.BaseProvider.IServiceProvider;

namespace Visitor.DI;

public class ServiceProviderDi(StandardKernel container) : IServiceProvisionUI, IServiceProvider
{
    public T GetService<T>() => (T)GetService(typeof(T));

    public object GetService(Type serviceType)
    {
        return container.Get(serviceType);
    }
}