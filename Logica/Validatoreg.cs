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
    
    public static bool TryValidObject(object instance, bool isErrorMessage)
    {
        string text = null;
        var results = new List<ValidationResult>();
        var context = new ValidationContext(instance);

        if (!Validator.TryValidateObject(instance, context, results))
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