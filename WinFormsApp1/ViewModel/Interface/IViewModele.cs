using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IViewModele<TEntity> : IViewModele
    where TEntity : Entity, new()
{
    public GenericRepositoryEntity<TEntity> GenericRepositoryEntity { get; protected set; }
}

public interface IViewModele
{
}