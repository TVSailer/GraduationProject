using Admin.ViewModel.GenericEntity;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Extension_Func_Library;
using Logica;
using Logica.Message;
using System.Runtime.CompilerServices;
using User_Interface_Library.GenericEntity;
using User_Interface_Library.Interface;
using Validaiger;

namespace Admin.ViewModel.AbstractFieldData;

public abstract class FieldData<TEntity> : PropertyChange, IDataUi<TEntity>
    where TEntity : Entity, new()
{
    public GenericRepositoryEntity<TEntity> MementoEntity
    {
        get
        {
            field ??= new GenericRepositoryEntity<TEntity>(this);
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

    public bool ValidObject(Action<GenericRepositoryEntity<TEntity>> action)
    {
        if (Validatoreg.TryValidObject(this, out var results))
        {
            action.Invoke(MementoEntity);
            return true;
        }

        results.ForEach(r => r.MemberNames.ForEach(m => OnMassageErrorProvider(r.ErrorMessage, m)));
        return false;
    }
}