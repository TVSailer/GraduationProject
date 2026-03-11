using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.PostgreSQL.Models.Imgs;

public class ImgLessonEntity : ImgEntity
{
    [ForeignKey(name: nameof(LessonEntity))]
    public long LessonId { get; set; }
    public LessonEntity Lesson { get; set; }

    public ImgLessonEntity() { }

    public ImgLessonEntity(string url) : base(url: url)
    {
    }
}