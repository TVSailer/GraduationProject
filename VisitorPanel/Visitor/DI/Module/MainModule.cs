using Ninject.Modules;
using UserInterface.View.Base;
using Visitor.View.Main;
using Visitor.ViewModel.Main;

namespace Visitor.DI.Module;

public class MainModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<MainPanelViewModel>>().To<MainPanelView>();
    }
}
