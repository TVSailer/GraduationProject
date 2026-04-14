using CSharpFunctionalExtensions;
using Domain.Enum;
using Domain.ValidObject;

namespace Domain.Entitys;

public class ReviewEntity : Entity
{
    public string Date { get; private set; } 
    public Estimation Rating { get; private set; }
    public string Comment { get; private set; }
    public VisitorEntity Visitor { get; private set; }
    public LessonEntity Lesson { get; private set; }

    private ReviewEntity() { }

    public ReviewEntity(Estimation rating, CommentValidObject comment, VisitorEntity visitor, LessonEntity lesson)
    {
        Rating = rating;
        Comment = comment.Text;
        Visitor = visitor;
        Lesson = lesson;

        Date = DateTime.Now.ToString(format: "dd/MM/yyyy");
    }

    public ReviewEntity UpdateRating(Estimation rating)
    {
        Rating = rating;
        return this;
    }

    public ReviewEntity UpdateComment(CommentValidObject comment)
    {
        Comment = comment.Text;
        return this;
    }
}