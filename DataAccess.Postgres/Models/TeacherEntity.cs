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
        public List<LessonEntity>? Lessons { get; set; } = new();
        public string UrlFaceImg { get; set; } = "";

        public TeacherEntity() { }
        public TeacherEntity(string name, string surname, string patro, string dateBurth, string numberPhone, string urlImg) 
        {
            FIO = new FIO(name, surname, patro);
            DateBirth = dateBurth;
            NumberPhone = numberPhone;
            UrlFaceImg = urlImg;
            Password = BCrypt.Net.BCrypt.HashPassword("1234");
            Login = "1234";
        }

        public override string ToString()
            => FIO.ToString();
    }
}
