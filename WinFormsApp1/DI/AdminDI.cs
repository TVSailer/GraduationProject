using Admin.Commands_Handlers.Managment;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Lesson;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Ninject;

internal static class AdminDI
{
    private static StandardKernel container;

    public static StandardKernel Container => container ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new LessonModule());

        var db = new ApplicationDbContext();
        var serviceProvader = new ServiceProviderDI(container);

        container.Bind<IMediator>().To<Mediator>().InSingletonScope();
        container.Bind<IServiceProvider>().ToConstant(serviceProvader).InSingletonScope();
        container.Bind<ILoggerFactory>().To<LoggerFactory>().InSingletonScope();

        container.Bind<ApplicationDbContext>().ToConstant(db).InSingletonScope();

        container.Bind<IView<AdminMainViewModel>, AdminMainView>().To<AdminMainView>().InSingletonScope();
        container.Bind<IViewModele, AdminMainViewModel>().To<AdminMainViewModel>().InSingletonScope();

        container.Bind<IRequest>().To<InitializeUI<AdminMainViewModel>>();
        container.Bind<IRequestHandler<InitializeUI<AdminMainViewModel>>>().To<InitializeUIHandler<AdminMainViewModel>>();

        // db.AddRange(
        //     new EventCategoryEntity("Спорт"),
        //     new EventCategoryEntity("Творчесво"),
        //     new EventCategoryEntity("Наука")
        //     );

        // db.AddRange(
        //     new TeacherEntity("dsf", "sdf", "lgh", "22.11.2004", "88989988989", ""),
        //     new TeacherEntity("jtr", "D", "DT", "22.11.2004", "88989988989", ""),
        //     new TeacherEntity("SREG", "AERF", "SASF", "22.11.2004", "88989988989", "")
        //     );

        // db.Teachers.ExecuteUpdate(t => t.SetProperty(t => t.Password, BCrypt.Net.BCrypt.HashPassword("1234")));
        // db.SaveChanges();

        return container;
    }

    public static T GetService<T>() where T : class
    {
        return Container.Get<T>();
    }

}