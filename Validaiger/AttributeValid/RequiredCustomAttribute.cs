using System.ComponentModel.DataAnnotations;

namespace Validaiger.AttributeValid
{
    public class RequiredCustomAttribute : RequiredAttribute
    {
        public RequiredCustomAttribute()
        {
            ErrorMessage = "Данное поле не может быть пустым!";
        }
    }
}
