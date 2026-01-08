using Admin.View.ViewForm;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WinFormsApp1.View;

namespace Admin.ViewModel
{
    public abstract class ManagmentModelView<T> : INotifyPropertyChanged
    {
        protected List<T> data;

        public ICommand OnBack { get; private set; }
        public abstract ICommand OnLoadAddingView { get; set; }
        public abstract ICommand OnLoadDetailsView { get; set; }
        public abstract ICommand OnSerch { get; set; }
        public abstract ICommand OnClearSerch { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<T> DataEntitys
        {
            get => data;
            set
            {
                if (data.SequenceEqual(value))
                    return;
                data = value;
                OnPropertyChanged();
            }
        }

        public ManagmentModelView(IViewForm mainForm, Repository<T> repository)
        {
            data = repository.Get();

            OnBack = new MainCommand(
                _ => mainForm.InitializeComponents());
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        
    }
}
