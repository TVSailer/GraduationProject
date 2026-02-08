using Admin.DI;
using Admin.Memento;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ninject;

internal static class AdminDI
{
    private static StandardKernel container;

    public static StandardKernel Container => container ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new LessonModule(),
            new VisitorModule());

        var db = new ApplicationDbContext();
        var serviceProvader = new ServiceProviderDI(container);

        container.Bind<IMediator>().To<Mediator>().InSingletonScope();
        container.Bind<IServiceProvider>().ToConstant(serviceProvader).InSingletonScope();
        container.Bind<ILoggerFactory>().To<LoggerFactory>().InSingletonScope();
        container.Bind<IServiceProvision>().ToConstant(serviceProvader).InSingletonScope();

        container.Bind<ApplicationDbContext>().ToConstant(db);

        container.Bind<AdminMainView, IView<AdminMainViewModel>>().To<AdminMainView>().InSingletonScope();
        container.Bind<AdminMainViewModel>().ToSelf();

        //container.GetService<Repository<LessonEntity>>().Get()[0].Visitors.Add(new VisitorEntity());
        // db.AddRange(
        //     new TeacherEntity("dsf", "sdf", "lgh", "22.11.2004", "88989988989", ""),
        //     new TeacherEntity("jtr", "D", "DT", "22.11.2004", "88989988989", ""),
        //     new TeacherEntity("SREG", "AERF", "SASF", "22.11.2004", "88989988989", "")
        //     );

        // db.Teachers.ExecuteUpdate(t => t.SetProperty(t => t.Password, BCrypt.Net.BCrypt.HashPassword("1234")));
        //db.SaveChanges();

        return container;
    }

    public static T GetService<T>() where T : class
    {
        return Container.Get<T>();
    }

}