using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid
{
    public class DateBirthdayAttribute(int minYears) : ValidationAttribute
    {
        public DateBirthdayAttribute() : this(18)
        {
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
            if (string.IsNullOrEmpty(birthDateStr))
            {
                ErrorMessage = $"Поле не может быть пустым!";
                return false;
            }

            if (DateTime.TryParseExact(birthDateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
            {
                if (birthDate.Year > DateTime.Today.Year - minYears)
                {
                    ErrorMessage = $"Не может быть младше {minYears} лет!";
                    return false;
                }

                if (birthDate.Year < DateTime.Today.Year - 100)
                {
                    ErrorMessage = "Не может быть старше 100 лет";
                    return false;
                }

                return true;
            }
            return false;
        }
    }
}
