using System.Reflection;
using System.Windows.Input;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Managment;

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

    public ICommand OnClearSerch { get; private set; }

    public SerchManagment(Repository<T> repository)
    {
        DataEntitys = repository.Get();

        OnClearSerch = new MainCommand(
            _ =>
            {
                DataEntitys = repository.Get();
                OnClearSerchFunk();
            });

        GetType()
            .GetProperties()
            .Where(p => p.GetCustomAttribute<FieldInfoUiAttribute>() != null)
            .ForEach(p =>
            {
                PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName.Equals(p.Name))
                        DataEntitys = OnSerhFunk(repository.Get());
                };
            });
    }

    public abstract Func<List<T>, List<T>> OnSerhFunk { get; protected set; }
    public abstract Action OnClearSerchFunk { get; protected set; }
}