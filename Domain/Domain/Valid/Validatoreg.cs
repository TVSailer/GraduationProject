using System.ComponentModel.DataAnnotations;

namespace Domain.Valid;

public static class Validatoreg
{
    public static bool TryValidObject(object instance, out List<ValidationResult> results)
    {
        results = [];
        var context = new ValidationContext(instance);

        return Validator.TryValidateObject(instance, context, results, true);
    }
    
    public static bool TryValidProperty(object value, string propertyName, object context, out List<ValidationResult> results)
    {
        results = [];
        var con = new ValidationContext(context) { MemberName = propertyName};

        return Validator.TryValidateProperty(value, con, results);
    }

    //public static bool TryOpenLink(string url)
    //{
    //    try
    //    {
    //        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
    //        {
    //            FileName = url,
    //            UseShellExecute = true
    //        });

    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}", "Ошибка",
    //                      MessageBoxButtons.OK, MessageBoxIcon.Error);

    //        return false;
    //    }
    //}
}