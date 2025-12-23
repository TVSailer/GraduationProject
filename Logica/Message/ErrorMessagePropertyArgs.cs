using System.ComponentModel;

namespace Logica.Massage;

public class ErrorMessagePropertyArgs
{
    public string? ErrorMessage { get; private set; }
    public string? PropertyName { get; private set; }

    public ErrorMessagePropertyArgs(string? errorText, PropertyChangedEventArgs propertyName)
    {
        ErrorMessage = errorText;
        PropertyName = propertyName.PropertyName;
    }
}
