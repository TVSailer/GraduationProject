using Admin.DI.Module;
using DataAccess.PostgreSQL;
using DataAccess.PostgreSQL.DI;
using Domain.Service.Image;
using Domain.Service.Image.BaseServiceImage;
using General.Service.ControlView;
using General.Service.ControlView.BaseControlView;
using General.Service.Image;
using General.Service.Image.BaseServiceImage;
using General.Service.ProvisionUI;
using Ninject;
using UserInterface.DIService;
using UserInterface.Service.FileDialog;
using UserInterface.Service.FileDialog.BaseFileDialog;
using UserInterface.Service.View;
using UserInterface.Service.View.Base;
using IServiceProvider = General.Service.ProvisionUI.IServiceProvider;

namespace Admin.DI;

public class MainDI
{
    public StandardKernel? Container => field ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new MainModule(),
            new DataAccesPastgreSqlDIModel(),
            //new VisitorModule(),
            //new ReviewModule(),
            new EventModule(),
            new NewsModule());
        //new DateAttendanceModule(),
        //new TeacherModule(),
        //new LessonModule());

        var serviceProvider = new ServiceProviderUI(container);

        container.Bind<ApplicationDbContext>().ToConstant(new ApplicationDbContext("DBConnectionString")).InSingletonScope();
        container.Bind<IServiceProvisionUI>().ToConstant(serviceProvider).InSingletonScope();
        container.Bind<IServiceProvider>().ToConstant(serviceProvider).InSingletonScope();
        container.Bind<IImageDialogService>().To<ImageDialogService>().InSingletonScope();
        container.Bind<IImageSelectionService>().To<ImageSelectionService>();
        container.Bind<IServiceImage>().To<ServiceImage>();
        container.Bind<IControlView>().To<ControlView>().InSingletonScope();
        container.Bind<IServiceControlView>().To<ServiceControlView>().InSingletonScope();

        return container;
    }

    public T GetService<T>() where T : class
    {
        return Container!.Get<T>();
    }
}