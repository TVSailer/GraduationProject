using Admin.DI.Module;
using DataAccess.PostgreSQL.DI;
using General.Service.ProviderUI;
using Ninject;
using UserInterface.DIService;
using IServiceProvider = Domain.Service.ProviderService.BaseProvider.IServiceProvider;

namespace Admin.DI;

public class MainDI
{
    public StandardKernel? Container => field ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new MainModule(),
            new DomainModule(),
            new UserInterfaceModule(),
            new CategoryModule(),
            new EnterModule(),
            new ReviewModule(),
            new DataAccesPostgreSqlModule(),
            new TeacherModule(),
            new EventModule(),
            new DateAttendanceModule(),
            new VisitorModule(),
            new LessonModule(),
            new NewsModule());

        var serviceProvider = new ServiceProviderUI(container);
        container.Bind<IServiceProvider>().ToConstant(serviceProvider).InSingletonScope();
        container.Bind<IServiceProvisionUI>().ToConstant(serviceProvider).InSingletonScope();

        return container;
    }

    public T GetService<T>() where T : class
    {
        return Container!.Get<T>();
    }
}