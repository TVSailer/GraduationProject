using Admin.ViewModel.AbstractFieldData;
using DataAccess.PostgreSQL.ComplexType;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Models.Imgs;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Attribute;
using Validaiger.AttributeValid;

namespace Admin.FieldData.Model.Event;

public class EventFieldData(CategoryRepository repository) : FieldDataWithImages<ImgEventEntity, EventEntity>
{
    [LinkingEntity(nameof(EventEntity.Imgs))]
    public List<ImgEventEntity> Images
    {
        get => ImagesData;
        set => ImagesData = value;
    }

    public List<CategoryEntity> Categorys => repository.Get();

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Title))]
    public string? Title { get; set => ValidProperty(ref field, value); }
    
    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.UrlTitleImag))]
    public string? UrlTitleImg { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Description))]
    public string? Description { get; set => ValidProperty(ref field, value); }

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
    [DateFieldUi("Дата: ", "dd.MM.yyyy")]
    public string Date
    {
        get => DateTime.Parse(field) < DateTime.Now.Date ? DateTime.Now.Date.ToString("dd/MM/yyyy") : field;
        set => OnPropertyChanged(ref field, value);
    } = DateTime.Now.Date.ToString("dd/MM/yyyy");

    public string Start { get; set => OnPropertyChanged(ref field, value); } = "10:00";

    public string End { get; set => OnPropertyChanged(ref field, value); } = "12:00";

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Location))]
    public string? Location { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Category))]
    public CategoryEntity? Category { get; set => ValidProperty(ref field, value); }

    [HttpsLink]
    [LinkingEntity(nameof(EventEntity.RegistrationLink))]
    public string? RegisLink { get; set => ValidProperty(ref field, value); }

    [RequiredCustom]
    [LinkingEntity(nameof(EventEntity.Organizer))]
    public string? Organizer { get; set => ValidProperty(ref field, value); }
}