using System.ComponentModel.DataAnnotations;

namespace Logica.CustomAttribute
{
    public class RequiredCustomAttribute : RequiredAttribute
    {
        public RequiredCustomAttribute()
        {
            ErrorMessage = "Данное поле не может быть пустым!";
        }
    }
}
