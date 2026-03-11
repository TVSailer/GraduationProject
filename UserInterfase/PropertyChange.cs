using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using UserInterface.Message;

namespace UserInterface;

public class PropertyChange : INotifyPropertyChanged, IMessageErrorProvider
{
    public event ErrorMessegePropertyHandler? ErrorMassegeProvider;
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public void OnMassageErrorProvider(string? errorMassage, [CallerMemberName] string prop = "")
    {
        ErrorMassegeProvider?.Invoke(this,
            new ErrorMessagePropertyArgs(errorMassage, new PropertyChangedEventArgs(prop)));
    }

    public void OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string pr = "")
    {
        if (value != null && value.Equals(field)) return;
        field = value;
        OnPropertyChanged(pr);
    }
}
