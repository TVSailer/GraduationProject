using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

namespace Admin.ViewModels.Lesson
{
    public abstract class SerchManagment<T> : PropertyChange
        where T : Entity
    {
        public List<T> DataEntitys
        {
            get;
            set
            {
                field = value;
                OnPropertyChanged();
            }
        }

        public ICommand OnSerch { get; private set; }
        public ICommand OnClearSerch { get; private set; }

        public SerchManagment(Repository<T> repository)
        {
            DataEntitys = repository.Get();

            OnSerch = new MainCommand(
                _ => DataEntitys = OnSerhFunk(repository.Get()));

            OnClearSerch = new MainCommand(
                _ =>
                {
                    DataEntitys = repository.Get();
                    OnClearSerchFunk();
                });
        }

        public abstract Func<List<T>, List<T>> OnSerhFunk { get; protected set; }
        public abstract Action OnClearSerchFunk { get; protected set; }
    }
}