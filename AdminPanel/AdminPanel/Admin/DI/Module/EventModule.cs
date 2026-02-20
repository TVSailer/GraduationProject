using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Event;
using Admin.ViewModel.Model.Event.Buttons;
using Admin.ViewModel.Model.Lesson.Buttons;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Ninject.Modules;
using WinFormsApp1.ViewModelEntity.Event;

namespace Admin.DI;

public record EventManagment : IFieldData;
public class EventAddingFieldData(EventCategoryRepository eventCategoryRepository)
    : EventFieldData(eventCategoryRepository);
public class EventDetailsFieldData(EventCategoryRepository eventCategoryRepository)
    : EventFieldData(eventCategoryRepository);

public class EventModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<EventEntity>>().To<EventRepository>().InSingletonScope();

        Kernel.Bind<IParametersSearch<EventEntity, EventFieldSearch>>().To<EventSearch>();

        Kernel.Bind<IView<EventAddingFieldData>>().To<BaseUI<EventAddingFieldData, EventEntity, EventAddingButton>>();
        Kernel.Bind<IView<EventDetailsFieldData, EventEntity>>().To<BaseUI<EventDetailsFieldData, EventEntity, EventDetailsButton>>();
        Kernel.Bind<IView<EventManagment>>().To<ManagmentEntityUi<
            EventManagment,
            EventEntity,
            EventFieldSearch,
            EventCard,
            EventManagmentButton>>();

        Kernel.Bind<EventManagmentButton>().ToSelf();
        Kernel.Bind<EventAddingButton>().ToSelf();
        Kernel.Bind<EventDetailsButton>().ToSelf();
    }
}