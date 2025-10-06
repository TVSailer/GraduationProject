using DataAccess.Postgres.Models;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Postgres.Attributes
{
    public class DateBirthdayAttribute : ValidationAttribute
    {
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
                if (birthDate > DateTime.Today)
                    return false;

                if (birthDate.Year < DateTime.Today.Year - 150)
                    return false;

                return true;
            }
            return false;
        }
    }
}
