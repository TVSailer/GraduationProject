using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid
{
    public class DateBirthdayAttribute : ValidationAttribute
    {
        private readonly int _minYears;

        public DateBirthdayAttribute()
        {
            _minYears = 18;
        }

        public DateBirthdayAttribute(int minYears)
        {
            _minYears = minYears;
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
                if (birthDate.Year > DateTime.Today.Year - _minYears)
                {
                    ErrorMessage = $"не может быть младше {_minYears} лет!";
                    return false;
                }

                if (birthDate.Year < DateTime.Today.Year - 100)
                {
                    ErrorMessage = "не может быть старше 100 лет";
                    return false;
                }

                return true;
            }
            return false;
        }
    }
}
