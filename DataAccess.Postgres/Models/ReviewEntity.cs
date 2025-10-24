using DataAccess.Postgres.Models;
using System.ComponentModel.DataAnnotations;

public class ReviewEntity
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Отсутствует автор")]
    public string Author { get; set; }
    public string Date { get; set; } = Convert.ToString(DateTime.Now);
    public int Rating { get; set; }
    [Required(ErrorMessage = "Отсутствует комментарий")]
    public string Comment { get; set; }
    public VisitorEntity Visitor { get; set; }
    public LessonEntity Lesson { get; set; }


    public ReviewEntity() { }
}
