using CSharpFunctionalExtensions;
using Logica;
using System.Reflection;
using System.Windows.Input;

namespace Admin.ViewModel.Managment;

public abstract class SearchEntity<TEntity, T> : PropertyChange
    where T : PropertyChange
    where TEntity : Entity, new()
{
    private Func<List<TEntity>> data;
    public readonly object Field;

    public List<TEntity> DataEntitys
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public ICommand OnClearSerch => new MainCommand(
        _ =>
        {
            DataEntitys = data.Invoke();
            field.GetType()
                .GetProperties()
                .ForEach(p => p.SetValue(this, p.GetCustomAttribute<FieldStateAttribute>().Data));
        });

    public SearchEntity(Func<List<TEntity>> data, T field, Func<T, List<TEntity>, List<TEntity>> search)
    {
        this.data = data;
        Field = field;
        DataEntitys = data.Invoke();
        field.PropertyChanged += (s, e) => DataEntitys = search(field, data.Invoke());
    }

    public void SetData(Func<List<TEntity>> data)
    {
        this.data = data;
        DataEntitys = data.Invoke();
    }
}