using Admin.View.AdminMain;
using Admin.ViewModel.AdminMain;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class MainModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<AdminPanelViewModel>>().To<AdminPanelView>();
    }
}