using System.ComponentModel.DataAnnotations;

namespace Domain.Valid.AttributeValid;

public class OrganizerAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string des)
        {
            if (string.IsNullOrEmpty(des))
            {
                ErrorMessage = "Названиме организации не может быть пустым";
                return false;
            }

            if (des.Length > 20)
            {
                ErrorMessage = "Название организации не может превышать 20 симмволов";
                return false;
            }

            return true;
        }
        ErrorMessage = "Названиме организации не может быть пустым";
        return true;
    }
}