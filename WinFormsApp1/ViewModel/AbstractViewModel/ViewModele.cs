using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica;
using System.Runtime.CompilerServices;

public abstract class ViewData<TEntity> : PropertyChange, IViewData<TEntity>
    where TEntity : Entity, new()
{
    public GenericRepositoryEntity<TEntity> Entity { get; set; } = new();


    public ViewData()
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
