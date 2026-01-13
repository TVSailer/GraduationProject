using System.ComponentModel.DataAnnotations;

namespace Logica.CustomAttribute
{
    public class MaxParticipantsAttribute : ValidationAttribute
    {
        public MaxParticipantsAttribute()
        {
            ErrorMessage = $"Неверно назвачено кол. поситетелей!";
        }

        public MaxParticipantsAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object? value)
        {
            if (value is int maxParticipants)
            {
                if (IsValidMaxParticipants(maxParticipants))
                    return true;
            }

            return false;
        }

        public bool IsValidMaxParticipants(int maxPart)
        {
            if (maxPart < 1)
            {
                ErrorMessage = "Кол-во поситителей не может быть меньше 1";
                return false;
            }

            return true;
        }
    }


}
