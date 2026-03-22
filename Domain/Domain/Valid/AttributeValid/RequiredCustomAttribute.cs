using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid
{
    public class RequiredCustomAttribute : RequiredAttribute
    {
        public RequiredCustomAttribute()
        {
            ErrorMessage = "Данное поле не может быть пустым!";
        }
    }
}
