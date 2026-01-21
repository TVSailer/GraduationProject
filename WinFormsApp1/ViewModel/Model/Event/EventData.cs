using Admin.View;
using Admin.View.Moduls.Event;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using DataAccess.Postgres.Models;
using Logica;
using Logica.CustomAttribute;
using WinFormsApp1;
using WinFormsApp1.ViewModelEntity.Event;

public abstract class EventData : ViewModelWithImages<EventEntity>
{
    [RequiredCustom] 
    [LinkingEntity("Title")]
    [BaseFieldUI("Название:*", "Введите название")]
    public string Title { get; set => 
            TryValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity("Description")]
    [MultilineFieldUI()]
    public string Description { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity("Date")]
    [DateFieldUI(CustomFormatDatePicker.dd_MM_yyyy_HH_mm)]
    public string Date { get; set => 
            TryValidProperty(ref field, value); }

    [RequiredCustom] 
    [LinkingEntity("Location")]
    [BaseFieldUI("Место:*", "Введите место проведения")]
    public string Location { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom] 
    [LinkingEntity("Category")]
    [BaseFieldUI("Категория:*", "Введите категорию")]
    public string Category { get; set => TryValidProperty(ref field, value); }

    [HttpsLink] 
    [LinkingEntity("RegistrationLink")]
    [BaseFieldUI("Ссылка на регистрацию:*", "Введите ссылку на регистрацию")]
    public string RegisLink { get; set => TryValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity("Organizer")]
    [BaseFieldUI("Организатор:*", "Введите фио организатора")]
    public string Organizer { get; set => TryValidProperty(ref field, value); }

    [MaxParticipants]
    [LinkingEntity("MaxParticipants")]
    [NumericFieldUI("Кол. участников:*")]
    public int MaxParticipants { get; set => 
            TryValidProperty(ref field, value); } = 1;

    public EventData()
    {
        OnBack = new MainCommand(
                _ => AdminDI.GetService<ManagementView<EventEntity, EventCard, EventAddingPanel, EventDetailsPanel>>().InitializeComponents(null));
    }
}
