using System.ComponentModel.DataAnnotations;

namespace Validaiger.AttributeValid
{
    public class NotNullAttribute : ValidationAttribute
    {
        public NotNullAttribute()
        {
            ErrorMessage = $"Данное поле не может быть пустым!";
        }

        public NotNullAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;

            return true;
        }
    }


}
