using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IViewModel<T> : IViewModele
{
}

public interface IViewModele<TEntity> : IViewModele
    where TEntity : Entity, new()
{
    GenericRepositoryEntity<TEntity> Entity { get; set; }
}

public interface IViewModele
{
}