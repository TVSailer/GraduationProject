using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Models;

public class NewsEntity
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Отсутствует название")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Отсутствует контент")]
    public string Content { get; set; }
    [Required(ErrorMessage = "Отсутствует дата написания")]
    public string Date { get; set; }
    [Required(ErrorMessage = "Отсутствует категория")]
    public string Category { get; set; }
    public List<ImgNew>? ImgsNew { get; set; } = new();

    public NewsEntity() { }

    public override string ToString()
        => $"Новость: {Title} {Date}";
}
