using System.Runtime.CompilerServices;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica;

namespace Admin.ViewModel.AbstractViewModel;

public abstract class FieldData<TEntity> : PropertyChange, IFieldData<TEntity>
    where TEntity : Entity, new()
{
    public GenericRepositoryEntity<TEntity> Entity { get; set; } = new();


    protected FieldData()
    {
        Entity.Initialize(this);
    }

    public T TryValidProperty<T>(ref T field, T value, [CallerMemberName] string prop = "")
    {
        field = value;

        Validatoreg.TryValidProperty(value, prop, this, out string errorMessage);
        OnMassegeErrorProvider(errorMessage, prop);
        OnPropertyChanged(prop);

        return value;
    }
}