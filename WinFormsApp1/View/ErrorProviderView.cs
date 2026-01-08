using Admin.ViewModel.NotifuPropertyViewModel;

public class ErrorProviderView
{
    private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
    private readonly NotifyPropertyViewModel context;

    public ErrorProviderView(NotifyPropertyViewModel context)
    {
        this.context = context;
    }

    protected void OnErrorProvider(string propertyName, Control control)
    {
        context.ErrorMassegeProvider += (s, e) =>
        {
            if (!propertyName.Equals(e.PropertyName)) return;
            errorProvider.SetError(control, e.ErrorMessage);
        };
    }
}

