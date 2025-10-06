using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DataAccess.Postgres.Attributes
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string phoneNumber)
            {
                if (IsValidPhoneNumber(phoneNumber))
                    return true;
            }

            return false;
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\+7|8)[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$";
            string cleanedPhoneNumber = Regex.Replace(phoneNumber, @"\s+", "");
            return Regex.IsMatch(cleanedPhoneNumber, pattern);
        }
    }
}
