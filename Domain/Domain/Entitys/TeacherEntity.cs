using CSharpFunctionalExtensions;
using Domain.ValidObject;
using System.Text.RegularExpressions;

namespace Domain.Entitys
{
    public class TeacherEntity : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string Image { get; private set; }
        public string DateBirth { get; private set; }
        public string NumberPhone { get; private set; }
        public AuthEntity AuthEntity { get; private set; }
        public ICollection<LessonEntity> Lessons { get; private set; } = [];

        private TeacherEntity() { }

        public TeacherEntity(
            ImageValidObject image, 
            NameValidObject name, 
            SurnameValidObject surname, 
            PatronymicValidObject patronymic, 
            DateBirthTeacherValidObject dateBirth, 
            NumberPhoneValidObject numberPhone, 
            AuthEntity authEntity)
        {
            Image = image.FileName;
            Name = name.Text;
            Surname = surname.Text;
            Patronymic = patronymic.Text;
            DateBirth = dateBirth.Text;
            NumberPhone = numberPhone.Text;
            AuthEntity = authEntity;
        }

        public TeacherEntity UpdateName(NameValidObject name)
        {
            Name = name.Text;
            return this;
        }

        public TeacherEntity UpdateSurname(SurnameValidObject surname)
        {
            Surname = surname.Text;
            return this;
        }

        public TeacherEntity UpdatePatronymic(PatronymicValidObject patronymic)
        {
            Patronymic = patronymic.Text;
            return this;
        }

        public TeacherEntity UpdateDateBirth(DateBirthTeacherValidObject date)
        {
            DateBirth = date.Text;
            return this;
        }

        public TeacherEntity UpdateNumberPhone(NumberPhoneValidObject number)
        {
            NumberPhone = number.Text;
            return this;
        }

        public TeacherEntity UpdateImage(ImageValidObject image)
        {
            Image = image?.FileName;
            return this;
        }

        public override string ToString() => $"{Name} {Surname} {Patronymic}";

        public bool Include(string? name, string? surname) => Name.StartsWith(name ?? "") && Surname.StartsWith(surname ?? "");
    }
}
