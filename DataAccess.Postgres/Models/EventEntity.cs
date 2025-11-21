using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataAccess.Postgres.Models;

public class EventEntity
{
    public int Id { get; private set; }
    [Required(ErrorMessage = "Отсутствует название!")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Отсутствует описание!")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Отсутствует дата проведения!")]
    public string Date { get; set; }
    [Required(ErrorMessage = "Отсутствует место проведения!")]
    public string Location { get; set; }
    [Required(ErrorMessage = "Отсутствует гатегория!")]
    public string Category { get; set; }
    [Required(ErrorMessage = "Отсутствует ссылка на регистрацию!")]
    public string RegistrationLink { get; set; }
    [Required(ErrorMessage = "Отсутствует организатор мероприятия!")]
    public string Organizer { get; set; }
    [Required(ErrorMessage = "Отсутствует возможное количество участников!")]
    public int MaxParticipants { get; set; }
    public int CurrentParticipants { get;  set; }
    public List<ImgEventEntity>? ImgsEvent { get; set; } = new();
    public string Participants => $"{CurrentParticipants} / {MaxParticipants}";
    public EventEntity() { }

    public EventEntity(string title, string description, string date, string location, string category, string regisLink, string organizer, int maxParticipants, int cuttentParticipants, List<ImgEventEntity> imgEventEntities) 
    {
        Title = title;
        Description = description;
        Date = date;
        Location = location;
        Category = category;
        RegistrationLink = regisLink;
        Organizer = organizer;
        MaxParticipants = maxParticipants;
        CurrentParticipants = cuttentParticipants;
        ImgsEvent = imgEventEntities;
    }

    public override string ToString()
        => $"Мероприятие: {Title} {Date}";

}
