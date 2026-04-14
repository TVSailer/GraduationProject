using Ninject.Modules;
using UserInterface.View.Base;
using Visitor.View.Event;
using Visitor.ViewModel.Event;

namespace Visitor.DI.Module;

public class EventModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<EventPanelViewModel>>().To<EventPanelView>();
        Kernel.Bind<IView<EventManagerPanelViewModel>>().To<EventManagerPanelView>();
    }
}