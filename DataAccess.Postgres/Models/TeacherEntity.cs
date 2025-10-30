using BCrypt.Net;
using DataAccess.Postgres.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Models
{
    public class TeacherEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пж, норм имя впиши")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пж, норм фамилию впиши")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Пж, норм отчество впиши")]
        public string Patronymic { get; set; }

        [DateBirthday(ErrorMessage = "Не корректная дата рождения")]
        public string DateBirth { get; set; }

        [PhoneNumber(ErrorMessage = "Пж, норм номер телефон впиши")]
        public string NumberPhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<LessonEntity>? Lessons { get; set; }

        public TeacherEntity() { }
        public TeacherEntity(string name, string surname, string patro) 
        {
            Name = name;
            Surname = surname;
            Patronymic = patro;
        }

        public override string ToString()
            => $"{Surname} {Name} {Patronymic}";

        //public bool VerifyPassword(string password)
        //{
        //    return BCrypt.Net.BCrypt.Verify(password, Password);
        //}
    }
}