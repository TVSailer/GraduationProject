using Admin.View.Moduls.Event;
using Admin.ViewModel.Model.Event;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class EventModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<EventManagerPanelViewModel>>().To<EventManagerPanelView>();
        Kernel.Bind<IView<EventAddingPanelViewModel>>().To<EventAddingPanelView>();
        Kernel.Bind<IView<EventDetailsPanelViewModel>>().To<EventDetailsPanelView>();
    }
}