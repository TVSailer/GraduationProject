using Ninject.Modules;
using UserInterface.Service.View;
using UserInterface.Service.View.Base;

namespace Admin.DI.Module;

public class UserInterfaceModule() : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IControlView>().To<ControlView>().InSingletonScope();
    }
}