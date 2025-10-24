using DataAccess.Postgres.Models;

public class ImgLesson : Img
{
    public LessonEntity Lesson { get; set; }
    public ImgLesson() { }
}