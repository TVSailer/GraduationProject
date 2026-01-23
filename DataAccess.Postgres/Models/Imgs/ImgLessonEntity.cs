using DataAccess.Postgres.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class ImgLessonEntity : ImgEntity
{
    [ForeignKey(nameof(LessonEntity))]
    public long LessonId { get; private set; }
    public LessonEntity Lesson { get; private set; }

    public ImgLessonEntity() { }

    public ImgLessonEntity(string url) : base(url)
    {
    }
}