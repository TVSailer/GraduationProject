using System.ComponentModel.DataAnnotations;

namespace Logica.CustomAttribute
{
    public class HttpsLinkAttribute : ValidationAttribute
    {
        public HttpsLinkAttribute()
        {
            ErrorMessage = "Неверный URL!";
        }

        public HttpsLinkAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value is string link)
            {
                if (IsValidLink(link))
                    return true;
            }

            return false;
        }

        private bool IsValidLink(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                ErrorMessage = "Неведен URL";
                return false;
            }

            if (!Uri.TryCreate(link, UriKind.Absolute, out _))
            {
                ErrorMessage = "Введите корректный URL";
                return false;
            }

            return true;
        }
    }
}
