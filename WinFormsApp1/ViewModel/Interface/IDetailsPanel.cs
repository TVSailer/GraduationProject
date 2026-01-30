using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IDetailsPanel<T> : IViewModele<T>
    where T : Entity, new()
{
    public void SetEntity(T entity) { }
}