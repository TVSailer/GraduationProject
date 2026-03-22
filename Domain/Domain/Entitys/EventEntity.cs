using CSharpFunctionalExtensions;
using Domain.Entitys.ComplexType;
using Domain.Entitys.ImagesEntity;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys;

public class EventEntity : Entity
{
    [Title] public string Title { get; set; }
    [Image] public string UrlTitleImag { get; set; }
    [Description] public string Description { get; set; }
    [Location] public string Location { get; set; }
    [Url] public string RegistrationLink { get; set; }
    [Organizer] public string Organizer { get;  set; }
    [Schedule] public EventSchedule Schedule { get; set; }
    public CategoryEntity Category { get; set; }
    public ICollection<ImageEventEntity> Images { get; set; } = [];

    private EventEntity() {}

    public EventEntity(string title, string urlTitleImag, string description, string location, string registrationLink, string organizer, EventSchedule schedule, CategoryEntity category, ICollection<ImageEventEntity> images)
    {
        Title = title;
        UrlTitleImag = urlTitleImag;
        Description = description;
        Location = location;
        RegistrationLink = registrationLink;
        Organizer = organizer;
        Schedule = schedule;
        Category = category;
        Images = images;
    }

    public override string ToString()
        => $"{Title} {Schedule}";
}


