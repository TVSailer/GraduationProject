using System.ComponentModel;

namespace UserInterface.Message.ErrorMessage;

public class ErrorMessagePropertyArgs(string? errorText, PropertyChangedEventArgs propertyName)
{
    public string? ErrorMessage { get; private set; } = errorText;
    public string? PropertyName { get; private set; } = propertyName.PropertyName;
}
