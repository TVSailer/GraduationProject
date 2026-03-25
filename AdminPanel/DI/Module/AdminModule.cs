using Admin.View.Moduls.AdminMain;
using Admin.ViewModel.Model.AdminMain;
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