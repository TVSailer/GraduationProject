using Admin.ViewModels.NotifuPropertyViewModel;

public class ErrorProviderView
{
    private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
    protected readonly PropertyChange context;

    public ErrorProviderView(PropertyChange context)
    {
        this.context = context;
    }

    public void OnErrorProvider(string propertyName, Control control)
    {
        context.ErrorMassegeProvider += (s, e) =>
        {
            if (!propertyName.Equals(e.PropertyName)) return;
            errorProvider.SetError(control, e.ErrorMessage);
        };
    }
}

