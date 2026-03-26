using CSharpFunctionalExtensions;
using Domain.Enum;

namespace Domain.Entitys;

public class ReviewEntity : Entity
{
    public string Date { get; set; } = DateTime.Now.ToString(format: "dd/MM/yyyy");
    public Estimation Rating { get; set; }
    public string Comment { get; set; }
    public VisitorEntity Visitor { get; set; }
    public LessonEntity Lesson { get; set; }

    private ReviewEntity() { }

    public ReviewEntity(Estimation rating, string comment, VisitorEntity visitor, LessonEntity lesson)
    {
        Rating = rating;
        Comment = comment;
        Visitor = visitor;
        Lesson = lesson;
    }
}