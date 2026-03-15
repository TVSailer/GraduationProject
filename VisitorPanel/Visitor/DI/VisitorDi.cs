using DataAccess.PostgreSQL;
using Ninject;
using UserInterface.Interface;
using UserInterface.View;
using Visitor.DI.Module;

namespace Visitor.DI;

public class VisitorDi
{
    public StandardKernel? Container => field ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new MainModule(),
            new EventModule(),
            new NewsModule(),
            new LessonModule());

        var serviceProvider = new ServiceProviderDi(container);

        container.Bind<ApplicationDbContext>().ToSelf().InSingletonScope();
        container.Bind<IServiceProvision>().ToConstant(serviceProvider);
        container.Bind<ControlView>().ToSelf().InSingletonScope();

        return container;
    }

    public T GetService<T>() where T : class
    {
        return Container!.Get<T>();
    }
}