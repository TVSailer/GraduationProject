using Logica.Massage;
using Logica.Message;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Admin.ViewModels.NotifuPropertyViewModel
{
    public abstract class PropertyChange : INotifyPropertyChanged, IMessageErrorProvider
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event ErrorMessegePropertyHandler? ErrorMassegeProvider;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public void OnMassegeErrorProvider(string? errorMesege, [CallerMemberName] string prop = "")
            => ErrorMassegeProvider?.Invoke(this, new ErrorMessagePropertyArgs(errorMesege, new PropertyChangedEventArgs(prop)));
    }
}
