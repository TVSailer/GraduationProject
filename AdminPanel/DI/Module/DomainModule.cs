using Domain.Service.AuthService;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.EntityService.TeacherService;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService;
using Domain.Service.SharedService.BaseSharedService;
using General.Service.ControlView;
using General.Service.File;
using General.Service.Message;
using Ninject.Modules;
using System.ComponentModel;

namespace Admin.DI.Module;

public class DomainModule() : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IImageService>().To<ImageService>();
        Kernel.Bind<IImageFileService>().To<ImageFileService>();
        Kernel.Bind<IControlViewService>().To<ControlViewService>().InSingletonScope();
        Kernel.Bind<ISharedService>().To<SharedService>().InSingletonScope();
        Kernel.Bind<IMessageService>().To<MessageService>();
        Kernel.Bind<IAuthFileService>().ToConstant(new AuthFileService("EnterAdmin")).InSingletonScope();
        Kernel.Bind<IAuthService>().To<AuthService>();
        Kernel.Bind<ITeacherService>().To<TeacherService>();
    }
}