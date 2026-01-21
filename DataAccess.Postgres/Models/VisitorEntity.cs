using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models
{
    public class VisitorEntity : Entity
    {
        public FIO FIO { get; set; }
        public string DateBirth { get; set; }
        public string NumberPhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UrlFaceImg { get; private set; }
        public List<LessonEntity>? Lessons { get; set; } = new();
        public List<DateAttendanceEntity>? Dates { get; set; } = new();
        public List<ReviewEntity>? Reviews { get; set; } = new();

        public VisitorEntity() { }

        public override string ToString()
        {
            return FIO.ToString();
        }
    }
}