using DataAccess.Postgres.Models;

public class ImgLessonEntity : ImgEntity
{
    public LessonEntity Lesson { get; set; }
    public ImgLessonEntity() { }
}