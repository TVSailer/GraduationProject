using Admin.View;
using Admin.View.ViewForm;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;
using WinFormsApp1.ViewModelEntity.Event;

public class EventModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<EventEntity>>().To<EventRepository>();
        Kernel.Bind<Repository<EventCategoryEntity>>().To<EventCategoryRepositroy>();

        Kernel.Bind<IViewModele<EventEntity>>().To<EventAddingPanel>();
        Kernel.Bind<IViewModele<EventEntity>>().To<EventDetailsPanel>();

        Kernel.Bind<IView<EventEntity>>().To<UIEntity<EventEntity, EventDetailsPanel>>();
        Kernel.Bind<IView<EventEntity>>().To<UIEntity<EventEntity, EventAddingPanel>>();

        Kernel.Bind<ManagmentModelView<EventEntity>>().ToSelf();
        Kernel.Bind<ManagementView<EventEntity, EventCard>>().ToSelf().InTransientScope();
        Kernel.Bind<SerchManagment<EventEntity>>().To<EventSerch>();

    }
}