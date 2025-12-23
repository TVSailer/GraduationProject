using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Admin.ViewModel
{
    public abstract class AbstractManagmentModelView : INotifyPropertyChanged
    {
        public abstract ICommand OnBack { get; set; }
        public abstract ICommand OnLoadAddingView { get; set; }
        public abstract ICommand OnLoadDetailsView { get; set; }
        public abstract ICommand OnSerch { get; set; }
        public abstract ICommand OnClearSerch { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
