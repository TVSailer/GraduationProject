using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models
{
    public class TeacherEntity : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string DateBirth { get; private set; }
        public string NumberPhone { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public List<LessonEntity>? Lessons { get; set; } = new();
        public string UrlFaceImg { get; private set; }

        public TeacherEntity() { }
        public TeacherEntity(string name, string surname, string patro, string dateBurth, string numberPhone, string urlImg) 
        {
            Name = name;
            Surname = surname;
            Patronymic = patro;
            DateBirth = dateBurth;
            NumberPhone = numberPhone;
            UrlFaceImg = urlImg;
            Password = "1234";
            Login = "1234";
        }

        public override string ToString()
            => $"{Surname} {Name} {Patronymic}";

        //public bool VerifyPassword(string password)
        //{
        //    return BCrypt.Net.BCrypt.Verify(password, Password);
        //}
    }
}