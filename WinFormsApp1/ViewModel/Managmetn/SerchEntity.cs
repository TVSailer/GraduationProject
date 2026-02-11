using System.Reflection;
using System.Windows.Input;
using Admin.Memento;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Managment;

public interface IParametersSearch<TEntiy, TFieldData>
    where TFieldData : IFieldData
    where TEntiy : Entity, new()
{
    public Func<TFieldData, List<TEntiy>, List<TEntiy>> SearchFunc { get; }
}

public class SearchEntity<TEntity, T>
    where T : PropertyChange, IFieldData
    where TEntity : Entity, new()
{
    public readonly T Field;
    private readonly Repository<TEntity> repository;
    public Action<List<TEntity>> OnSortEntity { get; set; }

    public List<TEntity> DataEntitys
    {
        get;
        private set
        {
            field = value;
            OnSortEntity?.Invoke(field);
        }
    }

    public ICommand OnClearSerch => new MainCommand(
        _ =>
        {
            DataEntitys = repository.Get();
            Field.GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttribute<FieldStateAttribute>() != null)
                .ForEach(p => p.SetValue(Field, p.GetCustomAttribute<FieldStateAttribute>().Data));
        });

    public SearchEntity(T field, Repository<TEntity> repository, IParametersSearch<TEntity, T> parameters)
    {
        DataEntitys = repository.Get();
        Field = field;
        this.repository = repository;
        Field.PropertyChanged += (s, e) => DataEntitys = parameters.SearchFunc(Field, repository.Get());
    }

    public List<TEntity> GetEntities()
    {
        return repository.Get();
    }
}