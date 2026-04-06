using DataAccess.PostgreSQL;
using Domain.Entitys;
using Domain.Service.MementoService;
using Domain.Service.MementoService.BaseMementoService;
using Ninject;
using UserInterface.Service.View;
using Visitor.DI.Module;
using IServiceProvider = Domain.Service.ProviderService.BaseProvider.IServiceProvider;

namespace Visitor.DI;

public class MainDI
{
    public StandardKernel? Container => field ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new MainModule(),
            new ReviewModule(),
            new EventModule(),
            new NewsModule(),
            new LessonModule());

        var serviceProvider = new ServiceProviderDi(container);

        container.Bind<ApplicationDbContext>().ToSelf().InSingletonScope();
        container.Bind<IServiceProvider>().ToConstant(serviceProvider);
        container.Bind<ControlView>().ToSelf().InSingletonScope();
        container.Bind<IMementoService<VisitorEntity>>().To<MementoService<VisitorEntity>>();
        container.Bind<IMementoService<LessonEntity>>().To<MementoService<LessonEntity>>();

        return container;
    }

    public T GetService<T>() where T : class
    {
        return Container!.Get<T>();
    }
}