using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class EventEntity : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }

    [ForeignKey(nameof(ScheduleEntity))]
    public long idDate { get; private set; }
    public ScheduleEntity Schedule { get; private set; }

    public string Location { get; private set; }

    [ForeignKey(nameof(EventCategoryEntity))]
    public long idCategory { get; private set; }
    public EventCategoryEntity Category { get; private set; }
    public string RegistrationLink { get; private set; }
    public string Organizer { get; private set; }
    public int MaxParticipants { get; private set; }
    public int CurrentParticipants { get;  private set; }
    public List<ImgEventEntity>? Imgs { get; set; } = new();

    public EventEntity() { }

    public EventEntity(string title, 
        string description, 
        ScheduleEntity date, 
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
