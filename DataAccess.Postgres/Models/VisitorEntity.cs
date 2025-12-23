namespace DataAccess.Postgres.Models
{
    public class VisitorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
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
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}