using System.ComponentModel.DataAnnotations;

namespace Logica.CustomAttribute
{
    public class DateBirthdayAttribute : ValidationAttribute
    {
        public DateBirthdayAttribute()
        {
            ErrorMessage = "Неверно набрана дата рождения!";
        }

        public DateBirthdayAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value is string birthDate)
            {
                if (IsValidBirthday(birthDate))
                    return true;
            }

            return false;
        }

        private bool IsValidBirthday(string? birthDateStr)
        {
            if (DateTime.TryParseExact(birthDateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
            {
                if (birthDate.Year > DateTime.Today.Year - 18)
                {
                    ErrorMessage = "Сотрудник должен быть младше 18 лет!";
                    return false;
                }

                if (birthDate.Year < DateTime.Today.Year - 100)
                {
                    ErrorMessage = "Сотрудник не может быть старше 100 лет";
                    return false;
                }

                return true;
            }
            return false;
        }
    }
}
