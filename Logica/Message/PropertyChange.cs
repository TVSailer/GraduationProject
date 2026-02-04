using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logica.Massage;
using Logica.Message;

public class PropertyChange : INotifyPropertyChanged, IMessageErrorProvider
{
    public event ErrorMessegePropertyHandler? ErrorMassegeProvider;
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public void OnMassegeErrorProvider(string? errorMesege, [CallerMemberName] string prop = "")
    {
        ErrorMassegeProvider?.Invoke(this,
            new ErrorMessagePropertyArgs(errorMesege, new PropertyChangedEventArgs(prop)));
    }
}