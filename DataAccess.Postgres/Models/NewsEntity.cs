using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Models;

public class NewsEntity
{
    public int Id { get; set; }
    public string UrlImg { get; set; }
    [Required(ErrorMessage = "Отсутствует название")]
    public required string Title { get; set; }
    [Required(ErrorMessage = "Отсутствует контента")]
    public required string Content { get; set; }
    [Required(ErrorMessage = "Отсутствует дата написания")]
    public required string Date { get; set; }
    [Required(ErrorMessage = "Выберите категорию")]
    public required string Category { get; set; }

    public override string ToString()
        => $"Новость: {Title} {Date}";
}
