using Admin.View.Enter;
using Admin.ViewModel.Enter;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class EnterModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IForma<EnterPanelViewModel>>().To<EnterPanelView>();
    }
}