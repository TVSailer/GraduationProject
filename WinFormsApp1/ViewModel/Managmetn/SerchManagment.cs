using System.Reflection;
using System.Windows.Input;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Managment;

public abstract class SerchEntity<TEntity> : PropertyChange
    where TEntity : Entity, new()
{
    public List<TEntity> DataEntitys
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public ICommand OnClearSerch { get; private set; }

    public SerchEntity(Repository<TEntity> repository)
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

    public abstract Func<List<TEntity>, List<TEntity>> OnSerhFunk { get; protected set; }
    public abstract Action OnClearSerchFunk { get; protected set; }
}