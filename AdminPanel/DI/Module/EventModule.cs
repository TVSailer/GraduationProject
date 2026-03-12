using Admin.FieldData.Model.Event;
using Admin.FieldData.Model.Event.Buttons;
using Admin.View;
using Admin.View.Moduls.Event;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI.Module;

public record EventManager;

public class EventModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<EventEntity>>().To<EventRepository>().InSingletonScope();

        Kernel.Bind<UiView<EventFieldData>>().To<EventPanelUi<EventAddingButton>>();
        Kernel.Bind<UiView<EventFieldData, EventEntity>>().To<EventPanelUi<EventDetailsButton>>();
        Kernel.Bind<UiView<EventManager>>().To<ManagerEntityUi<
            EventManager,
            EventEntity,
            EventFieldSearch,
            EventCard,
            EventManagerClicked>>();
    }
}