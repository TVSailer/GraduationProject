using Admin.ViewModel.AbstractFieldData;
using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.CustomAttribute;

namespace Admin.ViewModel.Model.Event;

public class EventFieldData(EventCategoryRepository repository) : FieldModelWithImages<EventEntity>
{
    public List<EventCategoryEntity> Categorys => repository.Get();

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Title))]
    [BaseFieldUi("Название:*", "Введите название")]
    public string Title { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Description))]
    [MultilineFieldUi()]
    public string Description { get; set => ValidProperty(ref field, value); }

    [LinkingEntity(nameof(EventEntity.Schedule))]
    public EventScheduleEntity? Schedule
    {
        get => new (TimeOnly.Parse(Start), TimeOnly.Parse(End), DateOnly.Parse(Date));
        set
        {
            Date = value.Date;
            Start = value.Start.ToString();
            End = value.End.ToString();
        }
    }
    [DateFieldUi("Дата:", "dd.MM.yyyy")]
    public string Date
    {
        get => DateTime.Parse(field) < DateTime.Now.Date ? DateTime.Now.Date.ToString("dd/MM/yyyy") : field;
        set => OnPropertyChange(ref field, value);
    } = DateTime.Now.Date.ToString("dd/MM/yyyy");

    [DateFieldUi("Начало:", "HH:mm")]
    public string Start { get; set => OnPropertyChange(ref field, value); } = "10:00";

    [DateFieldUi("Конец", "HH:mm")]
    public string End { get; set => OnPropertyChange(ref field, value); } = "12:00";

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Location))]
    [BaseFieldUi("Место:*", "Введите место проведения")]
    public string Location { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Category))]
    [ComboBoxFieldUi("Категория:*", nameof(Categorys))]
    public EventCategoryEntity Category { get; set => ValidProperty(ref field, value); }

    [HttpsLink]
    [LinkingEntity(nameof(EventEntity.RegistrationLink))]
    [BaseFieldUi("Ссылка на регистрацию:*", "Введите ссылку на регистрацию")]
    public string RegisLink { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Organizer))]
    [BaseFieldUi("Организатор:*", "Введите фио организатора")]
    public string Organizer { get; set => ValidProperty(ref field, value); }

    [LinkingEntity(nameof(EventEntity.MaxParticipants))]
    [NumericFieldUi("Кол. участников:*")]
    public int MaxParticipants { get; set => ValidProperty(ref field, value); } = 1;
}