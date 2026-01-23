using Admin.View;
using Admin.View.Moduls.Event;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using WinFormsApp1;
using WinFormsApp1.ViewModelEntity.Event;

public abstract class EventData : ViewModelWithImages<EventEntity>
{
    public readonly List<EventCategoryEntity> category;

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Title)), BaseFieldUi("Название:*", "Введите название")]
    public string Title { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Description)), MultilineFieldUi()]
    public string Description { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Schedule)), DateFieldUi(CustomFormatDatePicker.dd_MM_yyyy_HH_mm)]
    public EventScheduleEntity Date { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Location)), BaseFieldUi("Место:*", "Введите место проведения")]
    public string Location { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Category)), ComboBoxFieldUi("Категория:*", nameof(category))]
    public EventCategoryEntity Category { get; set => TryValidProperty(ref field, value); }

    [HttpsLink, LinkingEntity(nameof(EventEntity.RegistrationLink)),
     BaseFieldUi("Ссылка на регистрацию:*", "Введите ссылку на регистрацию")]
    public string RegisLink { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Organizer)), BaseFieldUi("Организатор:*", "Введите фио организатора")]
    public string Organizer { get; set => TryValidProperty(ref field, value); }

    [MaxParticipants, LinkingEntity(nameof(EventEntity.MaxParticipants)), NumericFieldUi("Кол. участников:*")]
    public int MaxParticipants { get; set => TryValidProperty(ref field, value); } = 1;

    public EventData(EventCategoryRepositroy eventCategoryRepositroy)
    {
        category = eventCategoryRepositroy.Get();

        OnBack = new MainCommand(
                _ => AdminDI.GetService<ManagementView<EventEntity, EventCard>>().InitializeComponents(null));
    }
}
