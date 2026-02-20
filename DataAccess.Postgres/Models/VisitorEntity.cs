using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class VisitorEntity : Entity
{
    public FIO FIO { get; set; } = new ("", "", "");
    public string DateBirth { get; set; } = "";
    public string NumberPhone { get; set; } = "";
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public string UrlFaceImg { get; set; } = "";
    public List<LessonEntity>? Lessons { get; set; } = [];
    public List<DateAttendanceEntity>? Dates { get; set; } = [];
    public List<ReviewEntity>? Reviews { get; set; } = [];

    public override string ToString()
    {
        return FIO.ToString();
    }
}