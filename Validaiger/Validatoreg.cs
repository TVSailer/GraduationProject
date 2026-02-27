using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Validaiger;

public static class Validatoreg
{
    public static bool TryValidObject(object instance, out List<ValidationResult> results)
    {
        results = [];
        var context = new ValidationContext(instance);

        return Validator.TryValidateObject(instance, context, results, true);
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

    public static bool TryOpenLink(string url)
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