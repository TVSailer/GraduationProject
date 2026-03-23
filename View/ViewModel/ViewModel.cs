using Domain.Valid;
using ExtensionFunc;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserInterface.Message.ErrorMessage;

namespace Abstract.ViewModel;

public abstract class ViewModel : INotifyPropertyChanged, IMessageErrorProvider
{
    public event ErrorMessegePropertyHandler? ErrorMassegeProvider;
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChange([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    protected void OnMassageErrorProvider(string? errorMassage, [CallerMemberName] string prop = "")
    {
        ErrorMassegeProvider?.Invoke(this,
            new ErrorMessagePropertyArgs(errorMassage, new PropertyChangedEventArgs(prop)));
    }

    protected bool Set<T>(ref T field, T value, [CallerMemberName] string pr = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;

        OnPropertyChange(pr);
        ValidProperty(value, pr);

        return true;
    }

    protected bool ValidProperty<T>(T value, [CallerMemberName] string prop = "")
    {
        if (!Validatoreg.TryValidProperty(value!, prop, this, out var errorMessage))
        {
            OnMassageErrorProvider("", prop);
            return false;
        }

        OnMassageErrorProvider(errorMessage.GroupBy(r => r.ErrorMessage).ToString(), prop);
        return true;
    }

    protected bool ValidObject()
    {
        if (Validatoreg.TryValidObject(this, out var results))
            return true;

        results.ForEach(r => r.MemberNames.ForEach(m => OnMassageErrorProvider(r.ErrorMessage, m)));
        return false;
    }
}
