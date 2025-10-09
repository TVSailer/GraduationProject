using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Models;

public class EventEntity
{
    public int Id { get; set; }
    public string UrlImg { get; set; }
    [Required(ErrorMessage = "Отсутствует название!")]
    public required string Title { get; set; }
    [Required(ErrorMessage = "Отсутствует описание!")]
    public required string Description { get; set; }
    [Required(ErrorMessage = "Отсутствует дата проведения!")]
    public required string Date { get; set; }
    [Required(ErrorMessage = "Отсутствует место проведения!")]
    public required string Location { get; set; }
    [Required(ErrorMessage = "Отсутствует гатегория!")]
    public required string Category { get; set; }
    [Required(ErrorMessage = "Отсутствует ссылка на регистрацию!")]
    public required string RegistrationLink { get; set; }
    [Required(ErrorMessage = "Отсутствует организатор мероприятия!")]
    public required string Organizer { get; set; }
    public int MaxParticipants { get; set; }
    [Required(ErrorMessage = "Отсутствует возможное количество участников!")]
    public int CurrentParticipants { get; set; }

    public override string ToString()
        => $"Мероприятие: {Title} {Date}";

}
