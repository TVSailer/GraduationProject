using Ninject.Modules;
using Teacher.View.Main;
using Teacher.ViewModel.Main;
using UserInterface.View.Base;

namespace Teacher.DI.Module;

public class MainModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<MainPanelViewModel>>().To<MainPanelView>();
    }
}
