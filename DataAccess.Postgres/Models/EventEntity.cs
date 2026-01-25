using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class EventEntity : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public EventScheduleEntity Schedule { get; set; }
    public string Location { get; set; }


    [ForeignKey(nameof(EventCategoryEntity))]
    public long CategoryId { get; set; }
    public EventCategoryEntity Category { get; set; }

    public string RegistrationLink { get; set; }
    public string Organizer { get;  set; }
    public int MaxParticipants { get; set; }
    public int CurrentParticipants { get;  set; }
    public List<ImgEventEntity>? Imgs { get; set; } = new();

    public EventEntity() { }

    public EventEntity(string title, 
        string description,
        EventScheduleEntity date, 
        string location, 
        EventCategoryEntity category, 
        string regisLink, 
        string organizer, 
        int maxParticipants, 
        List<ImgEventEntity> imgEventEntities) 
    {
        Title = title;
        Description = description;
        Schedule = date;
        Location = location;
        Category = category;
        RegistrationLink = regisLink;
        Organizer = organizer;
        MaxParticipants = maxParticipants;
        CurrentParticipants = 0;
        Imgs = imgEventEntities;
    }

    public override string ToString()
        => $"Мероприятие: {Title} {Schedule}";

}
