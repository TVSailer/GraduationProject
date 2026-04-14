using Ninject.Modules;
using UserInterface.View.Base;
using Visitor.View.Enter;
using Visitor.View.Visitor;
using Visitor.ViewModel.Enter;
using Visitor.ViewModel.Visitor;

namespace Visitor.DI.Module;

public class EnterModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<VisitorProfelPanelViewModel>>().To<VisitorProfelPanelView>();
        Kernel.Bind<IForma<EnterPanelViewModel>>().To<EnterPanelView>();
    }
}