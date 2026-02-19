using Admin.Memento;
using Admin.View;
using Admin.View.AdminMain;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ninject;

namespace Admin.DI;

public record AdminFieldData : IFieldData;

internal static class AdminDi
{
    private static StandardKernel container;

    public static StandardKernel Container => container ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new LessonModule(),
            new VisitorModule(),
            new ReviewModule(),
            new DateAttendanceModule());

        var db = new ApplicationDbContext();
        var serviceProvader = new ServiceProviderDI(container);

        container.Bind<IMediator>().To<Mediator>().InSingletonScope();
        container.Bind<IServiceProvider>().ToConstant(serviceProvader).InSingletonScope();
        container.Bind<ILoggerFactory>().To<LoggerFactory>().InSingletonScope();
        container.Bind<IServiceProvision>().ToConstant(serviceProvader).InSingletonScope();

        container.Bind<ApplicationDbContext>().ToConstant(db);

        container.Bind<AdminMainUi, IView<AdminFieldData>>().To<AdminMainUi>();
        container.Bind<AdminFieldData>().ToSelf();
        container.Bind<AdminMainViewButton>().ToSelf();

        container.Bind<MementoView>().ToSelf().InSingletonScope();
        container.Bind<ControlView>().ToSelf().InSingletonScope();

        return container;
    }

    public static T GetService<T>() where T : class
    {
        return Container.Get<T>();
    }

}