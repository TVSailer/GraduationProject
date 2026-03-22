using Abstract.View;
using Admin.DI.Module;
using DataAccess.PostgreSQL;
using DataAccess.PostgreSQL.DI;
using Domain.DIService;
using Ninject;

namespace Admin.DI;

public class AdminDi
{
    public StandardKernel? Container => field ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new AdminModule(),
            new DataAccesPastgreSqlDIModel(),
            //new VisitorModule(),
            //new ReviewModule(),
            new EventModule(),
            new NewsModule());
        //new DateAttendanceModule(),
        //new TeacherModule(),
        //new LessonModule());

        var dbContext = new ApplicationDbContext("DBConnectionString");
        var serviceProvider = new ServiceProviderDi(container);

        container.Bind<ApplicationDbContext>().ToConstant(dbContext).InSingletonScope();
        container.Bind<IServiceProvision>().ToConstant(serviceProvider);
        container.Bind<ControlView>().ToSelf().InSingletonScope();

        return container;
    }

    public T GetService<T>() where T : class
    {
        return Container!.Get<T>();
    }
}