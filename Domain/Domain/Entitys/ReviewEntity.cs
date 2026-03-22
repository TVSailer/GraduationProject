using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;
using Domain.Enum;

namespace Domain.Entitys;

public class ReviewEntity : Entity
{
    public string Date { get; set; } = DateTime.Now.ToString(format: "dd/MM/yyyy");
    public Estimation Rating { get; set; }
    public string Comment { get; set; } = "";
    [ForeignKey(nameof(VisitorEntity))]
    public long VisitorId { get; set; }
    public VisitorEntity Visitor { get; set; }

    [ForeignKey(nameof(LessonEntity))]
    public long LessonId { get; set; }
    public LessonEntity Lesson { get; set; }
}