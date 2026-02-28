using System.Runtime.CompilerServices;
using CSharpFunctionalExtensions;
using Extension_Func_Library;
using UserInterface.GenericEntity;
using UserInterface.Interface;
using Validaiger;

namespace Admin.ViewModel.AbstractFieldData;

public abstract class FieldData<TEntity> : PropertyChange, IDataUi<TEntity>
    where TEntity : Entity, new()
{
    public TEntity Entity
    {
        get => MementoEntity.GetEntiyNotNull(); 
        set => MementoEntity.SetEntity(value.Id, value);
    }

    public required RepositoryEntity<TEntity> MementoEntity
    {
        get
        {
            field ??= new RepositoryEntity<TEntity>(this);
            return field;
        } 
        set;
    }

    public T ValidProperty<T>(ref T field, T value, [CallerMemberName] string prop = "")
    {
        OnPropertyChanged(ref field, value, prop);
        Validatoreg.TryValidProperty(value!, prop, this, out var errorMessage);
        OnMassageErrorProvider(errorMessage, prop);

        return value;
    }

    public bool ValidObject(Action<long, TEntity> action)
    {
        if (Validatoreg.TryValidObject(this, out var results))
        {
            action.Invoke(MementoEntity.Id, Entity);
            return true;
        }

        results.ForEach(r => r.MemberNames.ForEach(m => OnMassageErrorProvider(r.ErrorMessage, m)));
        return false;
    }
}