using System.ComponentModel.DataAnnotations;

namespace Logica;

public static class Validatoreg
{
    public static bool TryValidObject(object instance)
    {
        string text = null;
        var results = new List<ValidationResult>();
        var context = new ValidationContext(instance);

        if (!Validator.TryValidateObject(instance, context, results, true))
        {
            foreach (var error in results)
                text += error.ErrorMessage + " ";

            LogicaMessage.MessageError(text);
            return false;
        }

        return true;
    }
}