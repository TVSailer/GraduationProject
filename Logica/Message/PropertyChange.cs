using Logica.Massage;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Logica.Message;

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
}