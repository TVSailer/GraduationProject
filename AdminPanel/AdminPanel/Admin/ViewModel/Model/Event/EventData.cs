using System.ComponentModel.DataAnnotations;
using Admin.View;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using WinFormsApp1;

public abstract class EventData : ViewModelWithImages<EventEntity>
{
    public readonly List<EventCategoryEntity> category;

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Title)), BaseFieldUi("Название:*", "Введите название")]
    public string Title
    {
        get;
        set => TryValidProperty(ref field, value);
    }

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Description)), MultilineFieldUi()]
    public string Description
    {
        get;
        set => TryValidProperty(ref field, value);
    }

    [LinkingEntity(nameof(EventEntity.Schedule))]
    public EventScheduleEntity? Schedule
    {
        get => new (TimeOnly.Parse(Start), TimeOnly.Parse(End), DateTime.Parse(Date));
        set
        {
            Date = value.Date;
            Start = value.Start.ToString();
            End = value.End.ToString();
        }
    }

    [DateFieldUi("Дата:", CustomFormatDatePicker.dd_MM_yyyy)]
    public string Date
    {
        get => DateTime.Parse(field) < DateTime.Now.Date ? DateTime.Now.Date.ToString() : field;
        set
        {
            if (field == value)
                return;
            field = value;
            OnPropertyChanged();

        }
    } = DateTime.Now.Date.ToString();

    [DateFieldUi("Начало:", CustomFormatDatePicker.HH_mm)]
    public string Start
    {
        get;
        set
        {
            if (field == value)
                return;
            field = value;
            OnPropertyChanged();
        }
    } = "10:00";

    [DateFieldUi("Конец", CustomFormatDatePicker.HH_mm)]
    public string End
    {
        get;
        set
        {
            if (field == value)
                return;
            field = value;
            OnPropertyChanged();
        }
    } = "12:00";

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Location)), BaseFieldUi("Место:*", "Введите место проведения")]
    public string Location
    {
        get;
        set => TryValidProperty(ref field, value);
    }

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Category)), ComboBoxFieldUi("Категория:*", nameof(category))]
    public EventCategoryEntity Category
    {
        get;
        set => TryValidProperty(ref field, value);
    }

    [HttpsLink, LinkingEntity(nameof(EventEntity.RegistrationLink)),
     BaseFieldUi("Ссылка на регистрацию:*", "Введите ссылку на регистрацию")]
    public string RegisLink
    {
        get;
        set => TryValidProperty(ref field, value);
    }

    [RequiredCustom, LinkingEntity(nameof(EventEntity.Organizer)), BaseFieldUi("Организатор:*", "Введите фио организатора")]
    public string Organizer
    {
        get;
        set => TryValidProperty(ref field, value);
    }

    [LinkingEntity(nameof(EventEntity.MaxParticipants)), NumericFieldUi("Кол. участников:*")]
    public int MaxParticipants
    {
        get;
        set => TryValidProperty(ref field, value);
    } = 1;

    public EventData(EventCategoryRepositroy eventCategoryRepositroy) : base(new MainCommand(_ =>
        AdminDI.GetService<ManagementView<EventEntity, EventCard>>().InitializeComponents(null)))
    {
        category = eventCategoryRepositroy.Get();
    }
}
