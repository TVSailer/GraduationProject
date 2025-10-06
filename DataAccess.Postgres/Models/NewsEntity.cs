using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Models;

public class NewsEntity
{
    public int Id { get; set; }
    public string UrlImg { get; set; }
    [Required(ErrorMessage = "Отсутствует название")]
    public required string Name { get; set; }
    [Required(ErrorMessage = "Отсутствует описание")]
    public required string Description { get; set; }
    [Required(ErrorMessage = "Отсутствует дата проведения")]
    public required string Date { get; set; }

    public override string ToString()
        => $"Новость: {Name} {Date}";
}
