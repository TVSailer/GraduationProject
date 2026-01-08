using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Logica.CustomAttribute
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public PhoneNumberAttribute()
        {
            ErrorMessage = $"Неверно набран номер тел.!";
        }

        public PhoneNumberAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value is string phoneNumber)
            {
                if (IsValidPhoneNumber(phoneNumber))
                    return true;
            }

            return false;
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\+7|8)[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$";
            string cleanedPhoneNumber = Regex.Replace(phoneNumber, @"\s+", "");
            return Regex.IsMatch(cleanedPhoneNumber, pattern);
        }
    }
}
