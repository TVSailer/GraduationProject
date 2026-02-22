using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Postgres.Models;

public class ImgLessonEntity : ImgEntity
{
    [ForeignKey(name: nameof(LessonEntity))]
    public long LessonId { get; private set; }
    public LessonEntity Lesson { get; private set; }

    public ImgLessonEntity() { }

    public ImgLessonEntity(string url) : base(url: url)
    {
    }
}