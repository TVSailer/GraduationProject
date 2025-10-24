using System.ComponentModel.DataAnnotations;

public class NewsItem
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Отсутствует название")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Отсутствует контент")]
    public string Content { get; set; }
    [Required(ErrorMessage = "Отсутствует автор")]
    public string Author { get; set; }
    [Required(ErrorMessage = "Отсутствует дата")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Отсутствует категория")]
    public string Category { get; set; }
}

