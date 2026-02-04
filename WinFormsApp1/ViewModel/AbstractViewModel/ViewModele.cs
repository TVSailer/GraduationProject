using System.Runtime.CompilerServices;
using System.Windows.Input;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using Logica;

public abstract class ViewModele<TEntity> : PropertyChange, IViewModele<TEntity>
    where TEntity : Entity, new()
{
    public GenericRepositoryEntity<TEntity> Entity { get; set; } = new();


    public ViewModele()
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
