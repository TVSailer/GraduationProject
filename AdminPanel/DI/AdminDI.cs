using Admin.DI.Module;
using DataAccess.PostgreSQL;
using Ninject;
using UserInterface.Interface;
using UserInterface.View;

namespace Admin.DI;

public class AdminDi
{
    public StandardKernel? Container => field ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new AdminModule(),
            new VisitorModule(),
            new ReviewModule(),
            new EventModule(),
            new NewsModule(),
            new DateAttendanceModule(),
            new TeacherModule(),
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