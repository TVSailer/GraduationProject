using DataAccess.PostgreSQL;
using DataAccess.PostgreSQL.DI;
using Domain.Entitys;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MementoService;
using Domain.Service.MementoService.BaseMementoService;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService;
using Domain.Service.SharedService.BaseSharedService;
using General.Service.ControlView;
using General.Service.File;
using General.Service.Image;
using General.Service.Message;
using Ninject;
using UserInterface.DIService;
using UserInterface.Service.FileDialog;
using UserInterface.Service.FileDialog.BaseFileDialog;
using UserInterface.Service.View;
using UserInterface.Service.View.Base;
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
            new EnterModule(),
            new DataAccesPostgreSqlModule(),
            new EventModule(),
            new NewsModule(),
            new LessonModule());

        var serviceProvider = new ServiceProviderDi(container);

        container.Bind<ApplicationDbContext>().ToConstant(new ApplicationDbContext("DBConnectionString")).InSingletonScope();
        container.Bind<IServiceProvisionUI>().ToConstant(serviceProvider).InSingletonScope();
        container.Bind<IServiceProvider>().ToConstant(serviceProvider).InSingletonScope();
        container.Bind<IImageDialogService>().To<ImageDialogService>().InSingletonScope();
        container.Bind<IImageSelectionService>().To<ImageSelectionService>();
        container.Bind<IImageService>().To<ImageService>();
        container.Bind<IControlView>().To<ControlView>().InSingletonScope();
        container.Bind<IControlViewService>().To<ControlViewService>().InSingletonScope();
        container.Bind<ISharedService>().To<SharedService>().InSingletonScope();
        container.Bind<IMessageService>().To<MessageService>();
        container.Bind<IMementoService<VisitorEntity>>().To<MementoService<VisitorEntity>>().InSingletonScope();
        container.Bind<IMementoService<LessonEntity>>().To<MementoService<LessonEntity>>().InSingletonScope();
        container.Bind<IAuthFileService>().ToConstant(new AuthFileService("EnterVisitor")).InSingletonScope();

        return container;
    }

    public T GetService<T>() where T : class
    {
        return Container!.Get<T>();
    }
}