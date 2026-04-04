using Admin.DI.Module;
using DataAccess.PostgreSQL;
using DataAccess.PostgreSQL.DI;
using Domain.Service.AuthService;
using Domain.Service.AuthService.BaseAuthService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService;
using Domain.Service.SharedService.BaseSharedService;
using General.Service.ControlView;
using General.Service.Image;
using General.Service.Message;
using General.Service.ProvisionUI;
using Ninject;
using UserInterface.DIService;
using UserInterface.Service.FileDialog;
using UserInterface.Service.FileDialog.BaseFileDialog;
using UserInterface.Service.View;
using UserInterface.Service.View.Base;
using IServiceProvider = Domain.Service.ProviderService.BaseProvider.IServiceProvider;

namespace Admin.DI;

public class MainDI
{
    public StandardKernel? Container => field ??= ConfigurationContainer();

    private static StandardKernel ConfigurationContainer()
    {
        var container = new StandardKernel(
            new MainModule(),
            new ReviewModule(),
            new DataAccesPostgreSqlModule(),
            new TeacherModule(),
            new EventModule(),
            new DateAttendanceModule(),
            new VisitorModule(),
            new LessonModule(),
            new NewsModule());

        var serviceProvider = new ServiceProviderUI(container);

        container.Bind<ApplicationDbContext>().ToConstant(new ApplicationDbContext("DBConnectionString")).InSingletonScope();
        container.Bind<IServiceProvisionUI>().ToConstant(serviceProvider).InSingletonScope();
        container.Bind<IServiceProvider>().ToConstant(serviceProvider).InSingletonScope();
        container.Bind<IImageDialogService>().To<ImageDialogService>().InSingletonScope();
        container.Bind<IImageSelectionService>().To<ImageSelectionService>();
        container.Bind<IImageService>().To<ImageService>();
        container.Bind<IControlView>().To<ControlView>().InSingletonScope();
        container.Bind<IControlViewService>().To<ControlViewService>().InSingletonScope();
        container.Bind<ISharedService>().To<SharedService>().InSingletonScope();
        container.Bind<IAuthService>().To<AuthService>();
        container.Bind<IMessageService>().To<MessageService>();

        return container;
    }

    public T GetService<T>() where T : class
    {
        return Container!.Get<T>();
    }
}