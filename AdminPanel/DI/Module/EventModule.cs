using Ninject.Modules;

namespace Admin.DI.Module;

public record EventManager;

public class EventModule : NinjectModule
{
    public override void Load()
    {
        //Kernel.Bind<UiView<EventFieldData>>().To<EventPanelUi<EventAddingButton>>();
        //Kernel.Bind<UiView<EventFieldData, EventEntity>>().To<EventPanelUi<EventDetailsButton>>();
        //Kernel.Bind<UiView<EventManager>>().To<ManagerEntityUi<
        //    EventManager,
        //    EventEntity,
        //    EventFieldSearch,
        //    EventCard,
        //    EventManagerButtons>>();
    }
}