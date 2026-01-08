using System.ComponentModel.DataAnnotations;

namespace Logica;

public static class Validatoreg
{
    public static bool TryValidObject(object instance, bool isErrorMessage = false)
    {
        string text = "";
        var results = new List<ValidationResult>();
        var context = new ValidationContext(instance);

        if (!Validator.TryValidateObject(instance, context, results, true))
        {
            if (isErrorMessage)
            {
                foreach (var error in results)
                    text += error.ErrorMessage + " ";

                LogicaMessage.MessageError(text);
            }

            return false;
        }

        return true;
    }
    
    public static bool TryValidObject(object instance, out List<ValidationResult> results, bool isErrorMessage = false)
    {
        results = new List<ValidationResult>();
        var context = new ValidationContext(instance);

        if (!Validator.TryValidateObject(instance, context, results, true))
            return false;

        return true;
    }
    
    public static bool TryValidValue(object value, List<ValidationAttribute> validationAttributes, out string errorMessage, bool isErrorMessage = false)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(value);

        if (!Validator.TryValidateValue(value, context, results, validationAttributes))
        {
            string erText = "";
            results.ForEach(m => erText += m.ErrorMessage);
            errorMessage = erText;
            return false;
        }

        errorMessage = "";
        return true;
    }
    
    public static bool TryValidProperty(object value, string propertyName, object context, out string errorMessage)
    {
        var results = new List<ValidationResult>();
        var con = new ValidationContext(context) { MemberName = propertyName};

        if (!Validator.TryValidateProperty(value, con, results))
        {
            string erText = "";
            results.ForEach(m => erText += m.ErrorMessage);
            errorMessage = erText;
            return false;
        }

        errorMessage = "";
        return true;
    }
    
    public static bool TryValidProperty(object value, bool isErrorMessage = false)
    {
        string text = null;
        var results = new List<ValidationResult>();
        var context = new ValidationContext(value);

        if (!Validator.TryValidateProperty(value, context, results))
        {
            if (isErrorMessage)
            {
                foreach (var error in results)
                    text += error.ErrorMessage + " ";

                LogicaMessage.MessageError(text);
            }

            return false;
        }

        return true;
    }

    public static bool OpenLink(string url)
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}", "Ошибка",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }
    }
}