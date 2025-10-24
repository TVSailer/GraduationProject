using DataAccess.Postgres.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Models
{
    public class VisitorEntity
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