using System.ComponentModel.DataAnnotations;

namespace Logica.CustomAttribute
{
    public class ScheduleAttribute : ValidationAttribute
    {
        public ScheduleAttribute()
        {
            ErrorMessage = "Данное поле не может быть пустым!";
        }
    }
}
