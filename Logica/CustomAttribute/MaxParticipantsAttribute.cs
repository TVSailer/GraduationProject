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
                //if (IsValidMaxParticipants(maxParticipants))
                return true;
            }

            return false;
        }

        public bool IsValidMaxParticipants(string maxPart)
        {
            if (string.IsNullOrEmpty(maxPart))
            {
                ErrorMessage = "Данное поле не может быть пустым";
                return false;
            }
            if (!int.TryParse(maxPart, null, out int rezult))
            {
                ErrorMessage = "Значения целого числа";
                return false;

            }
            if (rezult < 1)
            {
                ErrorMessage = "Значения целого числа не может быть ниже нуля";
                return false;
            }

            return true;
        }
    }


}
