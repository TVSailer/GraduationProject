using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class EventEntity : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Date { get; private set; }
    public string Location { get; private set; }
    public string Category { get; private set; }
    public string RegistrationLink { get; private set; }
    public string Organizer { get; private set; }
    public int MaxParticipants { get; private set; }
    public int CurrentParticipants { get;  private set; }
    public List<ImgEventEntity>? ImgsEvent { get; set; } = new();

    public EventEntity() { }

    public EventEntity(string title, string description, string date, string location, string category, string regisLink, string organizer, int maxParticipants, int currentPart, List<ImgEventEntity> imgEventEntities) 
    {
        Title = title;
        Description = description;
        Date = date;
        Location = location;
        Category = category;
        RegistrationLink = regisLink;
        Organizer = organizer;
        MaxParticipants = maxParticipants;
        CurrentParticipants = 0;
        ImgsEvent = imgEventEntities;
    }
    
    public EventEntity(string title, string description, string date, string location, string category, string regisLink, string organizer, int maxParticipants, List<ImgEventEntity> imgEventEntities) 
    {
        Title = title;
        Description = description;
        Date = date;
        Location = location;
        Category = category;
        RegistrationLink = regisLink;
        Organizer = organizer;
        MaxParticipants = maxParticipants;
        CurrentParticipants = 0;
        ImgsEvent = imgEventEntities;
    }

    public override string ToString()
        => $"Мероприятие: {Title} {Date}";

}
