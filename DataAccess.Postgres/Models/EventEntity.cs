using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class EventEntity : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public EventScheduleEntity Schedule { get; set; }
    public string Location { get; set; }


    [ForeignKey(name: nameof(EventCategoryEntity))]
    public long CategoryId { get; set; }
    public EventCategoryEntity Category { get; set; }

    public string RegistrationLink { get; set; }
    public string Organizer { get;  set; }
    public int MaxParticipants { get; set; }
    public int CurrentParticipants { get;  set; }
    public List<ImgEventEntity>? Imgs { get; set; } = new();

    public override string ToString()
        => $"Мероприятие: {Title} {Schedule}";

}
