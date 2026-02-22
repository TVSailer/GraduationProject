using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models
{
    public class TeacherEntity : Entity
    {
        public FIO FIO { get; set; }
        public string DateBirth { get; set; }
        public string NumberPhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<LessonEntity> Lessons { get; set; } = [];
        public string UrlFaceImg { get; set; }
        public override string ToString() => FIO.ToString();
    }
}
