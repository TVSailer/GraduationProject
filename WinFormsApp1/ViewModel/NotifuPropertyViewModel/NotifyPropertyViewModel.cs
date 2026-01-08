using Logica;
using Logica.Massage;
using Logica.Message;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Admin.ViewModel.NotifuPropertyViewModel
{
    public abstract class NotifyPropertyViewModel : INotifyPropertyChanged, IMessageErrorProvider
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event ErrorMessegePropertyHandler? ErrorMassegeProvider;

        public void Set<T>(ref T file, T value, [CallerMemberName] string prop = "")
        {
            if (value is null) throw new ArgumentNullException();

            file = value;

            if (!Validatoreg.TryValidProperty(file, prop, this, out string errorMessage))
            {
                OnMassegeErrorProvider(errorMessage, prop);
                return;
            }

            OnMassegeErrorProvider("", prop);
            OnPropertyChanged(prop);
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public void OnMassegeErrorProvider(string? errorMesege, [CallerMemberName] string prop = "")
            => ErrorMassegeProvider?.Invoke(this, new ErrorMessagePropertyArgs(errorMesege, new PropertyChangedEventArgs(prop)));

    }
}
