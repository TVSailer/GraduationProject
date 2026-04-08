using CSharpFunctionalExtensions;
using Domain.ValidObject;
using System.Text.RegularExpressions;

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

        //TODO: delete
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
        
        public TeacherEntity(
            ImageValidObject image, 
            NameValidObject name, 
            SurnameValidObject surname, 
            PatronymicValidObject patronymic, 
            DateBirthTeacherValidObject dateBirth, 
            NumberPhoneValidObject numberPhone, 
            AuthEntity authEntity)
        {
            Image = image.Text;
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
            Image = image?.Text;
            return this;
        }

        public override string ToString() => $"{Name} {Surname} {Patronymic}";

        public bool Include(string? name, string? surname) => Name.StartsWith(name ?? "") && Surname.StartsWith(surname ?? "");
    }
}
