using Ninject.Modules;
using UserInterface.View.Base;
using Visitor.View.Enter;
using Visitor.View.Event;
using Visitor.View.Visitor;
using Visitor.ViewModel.Enter;
using Visitor.ViewModel.Event;
using Visitor.ViewModel.Visitor;

namespace Visitor.DI.Module;

public class EventModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<EventPanelViewModel>>().To<EventPanelView>();
        Kernel.Bind<IView<EventManagerPanelViewModel>>().To<EventManagerPanelView>();
    }
}
public class EnterModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<VisitorProfelPanelViewModel>>().To<VisitorProfelPanelView>();
        Kernel.Bind<IForma<EnterPanelViewModel>>().To<EnterPanelView>();
    }
}