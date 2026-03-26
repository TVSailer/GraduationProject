using CSharpFunctionalExtensions;

namespace Domain.Entitys
{
    public class TeacherEntity : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Image { get; set; }
        public string DateBirth { get; set; }
        public string NumberPhone { get; set; }
        public AuthEntity AuthEntity { get; set; }
        public ICollection<LessonEntity> Lessons { get; set; } = [];

        private TeacherEntity() { }

        public TeacherEntity(string image, string name, string surname, string patronymic, string dateBirth, string numberPhone, AuthEntity authEntity)
        {
            Image = image;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DateBirth = dateBirth;
            NumberPhone = numberPhone;
            AuthEntity = authEntity;
        }

        public override string ToString() => $"{Name} {Surname} {Patronymic}";

        public bool Include(string? name, string? surname) => Name.StartsWith(name ?? "") && Surname.StartsWith(surname ?? "");
    }
}
