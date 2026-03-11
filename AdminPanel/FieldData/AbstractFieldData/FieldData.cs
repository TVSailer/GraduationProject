using System.Runtime.CompilerServices;
using CSharpFunctionalExtensions;
using Extension_Func_Library;
using UserInterface;
using UserInterface.GenericEntity;
using UserInterface.Interface;
using Validaiger;

namespace Admin.FieldData.AbstractFieldData;

public abstract class FieldData<TEntity> : PropertyChange, IDataUi<TEntity>
    where TEntity : Entity, new()
{
    public bool NullEntity => MementoEntity.Entity == null;

    public TEntity Entity
    {
        get => MementoEntity.GetEntityNotNull(); 
        set => MementoEntity.SetEntity(value.Id, value);
    }

    public long EntityId
    {
        get => MementoEntity.Id;
        set => throw new NotImplementedException();
    }

    protected MementoEntity<TEntity> MementoEntity
    {
        get
        {
            field ??= new MementoEntity<TEntity>(this);
            return field;
        }
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