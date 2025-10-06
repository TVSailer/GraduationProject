using DataAccess.Postgres.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Models
{
    public class VisitorEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пж, норм имя впиши")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Пж, норм фамилию впиши")]
        public required string Surname { get; set; }
        [Required(ErrorMessage = "Пж, норм отчество впиши")]
        public required string Patronymic { get; set; }
        [DateBirthday(ErrorMessage = "Не корректная дата рождения")]
        public required string DateBirth { get; set; }
        [PhoneNumber(ErrorMessage = "Пж, норм номер телефон впиши")]
        public required string NumberPhone { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public List<LessonEntity>? Lessons { get; set; } = new();
        public List<DateAttendanceEntity>? Dates { get; set; } = new();

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}