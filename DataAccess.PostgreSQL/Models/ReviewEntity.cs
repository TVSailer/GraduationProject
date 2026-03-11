using System;
using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.Models;

public class ReviewEntity : Entity
{
    public string Date { get; set; } = DateTime.Now.ToString(format: "dd/MM/yyyy");
    public int Rating { get; set; }
    public string Comment { get; set; } = "";
    public VisitorEntity Visitor { get; set; }
    public LessonEntity Lesson { get; set; }
}
