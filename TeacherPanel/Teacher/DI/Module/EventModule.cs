using Ninject.Modules;
using Teacher.View.Event;
using Teacher.ViewModel.Event;
using UserInterface.View.Base;

namespace Teacher.DI.Module;

public class EventModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<EventPanelViewModel>>().To<EventPanelView>();
        Kernel.Bind<IView<EventManagerPanelViewModel>>().To<EventManagerPanelView>();
    }
}