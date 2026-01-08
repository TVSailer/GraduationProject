using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class ImgLessonEntity : Entity
{
    [ForeignKey(nameof(LessonEntity))]
    public long LessonId { get; private set; }
    public LessonEntity Lesson { get; private set; }
    public string Url { get; protected set; }

    public ImgLessonEntity() { }

    public ImgLessonEntity(string url)
    {
        Url = url;
    }
}