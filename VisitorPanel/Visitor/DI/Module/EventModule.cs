using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;
using Visitor.FieldData.Event;
using Visitor.FieldData.Event.Button;
using Visitor.View;
using Visitor.View.Event;

namespace Visitor.DI.Module;

public class EventManager;

public class EventModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<EventEntity>>().To<EventRepository>().InSingletonScope();

        Kernel.Bind<UiView<EventDataUi, EventEntity>>().To<EventPanelUi>();
        Kernel.Bind<UiView<EventManager>>().To<ManagerPanelUi<EventManager, EventEntity, EventCard, EventManagerButtons>>();
    }
}