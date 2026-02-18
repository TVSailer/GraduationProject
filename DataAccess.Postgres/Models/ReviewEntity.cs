using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;

public class ReviewEntity : Entity
{
    public string Date { get; set; } = Convert.ToString(DateTime.Now);
    public int Rating { get; set; }
    public string Comment { get; set; } = "";
    public VisitorEntity Visitor { get; set; }
    public LessonEntity Lesson { get; set; }

    public ReviewEntity(int rating, string comment, VisitorEntity visitor)
    {
        Rating = rating;
        Comment = comment;
        Visitor = visitor;
    }

    public ReviewEntity() { }
}
