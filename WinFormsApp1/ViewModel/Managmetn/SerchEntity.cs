using CSharpFunctionalExtensions;
using Logica;
using System.Reflection;
using System.Windows.Input;
using Admin.Memento;
using Admin.ViewModel.Interface;

namespace Admin.ViewModel.Managment;

public interface IParametersSearch<TEntiy, TFieldData>
    where TFieldData : IFieldData
    where TEntiy : Entity, new()
{
    public Func<TFieldData, List<TEntiy>, List<TEntiy>> SearchFunc { get; }
}

public class SearchEntity<TEntity, T> : PropertyChange
    where T : PropertyChange, IFieldData
    where TEntity : Entity, new()
{
    private readonly List<TEntity> data;
    public readonly T Field;

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
            DataEntitys = data;
            Field.GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttribute<FieldStateAttribute>() != null)
                .ForEach(p => p.SetValue(Field, p.GetCustomAttribute<FieldStateAttribute>().Data));
        });

    public SearchEntity(T field, MementoData<TEntity> memento, IParametersSearch<TEntity, T> parameters)
    {
        data = memento.Data;
        Field = field;
        DataEntitys = data;
        Field.PropertyChanged += (s, e) => DataEntitys = parameters.SearchFunc(Field, data);
    }
}