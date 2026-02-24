using Admin.Memento;
using Admin.View;
using DataAccess.Postgres;
using MediatR;
using Microsoft.Extensions.Logging;
using Ninject;

namespace Admin.DI;

public class AdminDi
{
    public StandardKernel? Container => field ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new AdminModule(),
            new LessonModule(),
            new VisitorModule(),
            new NewsModule(),
            new ReviewModule(),
            new DateAttendanceModule(),
            new EventModule(),
            new TeacherModule());

        var serviceProvider = new ServiceProviderDI(container);

        container.Bind<ApplicationDbContext>().ToSelf().InSingletonScope();
        container.Bind<IMediator>().To<Mediator>().InSingletonScope();
        container.Bind<IServiceProvider>().ToConstant(serviceProvider);
        container.Bind<IServiceProvision>().ToConstant(serviceProvider);
        container.Bind<ILoggerFactory>().To<LoggerFactory>().InSingletonScope();

        container.Bind<MementoView>().ToSelf().InSingletonScope();
        container.Bind<ControlView>().ToSelf().InSingletonScope();

        return container;
    }

    public T GetService<T>() where T : class
    {
        return Container!.Get<T>();
    }
}