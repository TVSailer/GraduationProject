using Admin.ViewModel.GenericEntity;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica;
using Logica.Message;
using System.Runtime.CompilerServices;

namespace Admin.ViewModel.AbstractFieldData;

public abstract class FieldData<TEntity> : PropertyChange, IFieldData<TEntity>
    where TEntity : Entity, new()
{
    public GenericRepositoryEntity<TEntity> Entity { get; set; } = new();

    protected FieldData()
    {
        Entity.Initialize(this);
    }

    public T ValidProperty<T>(ref T field, T value, [CallerMemberName] string prop = "")
    {
        field = value;

        Validatoreg.TryValidProperty(value!, prop, this, out var errorMessage);
        OnMassageErrorProvider(errorMessage, prop);
        OnPropertyChanged(prop);

        return value;
    }
    
    public T OnPropertyChange<T>(ref T field, T value, [CallerMemberName] string prop = "")
    {
        if (field!.Equals(value))
            return value;
        field = value;
        OnPropertyChanged(prop);

        return value;
    }

    public bool TryWordWithEntity(Action<GenericRepositoryEntity<TEntity>> action)
    {
        if (Validatoreg.TryValidObject(this, out var results))
        {
            action.Invoke(Entity);
            return true;
        }

        results.ForEach(r => r.MemberNames.ForEach(m => OnMassageErrorProvider(r.ErrorMessage, m)));
        return false;
    }
}