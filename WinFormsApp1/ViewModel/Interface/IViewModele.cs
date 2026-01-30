using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IViewModele<TEntity> : IViewModele
    where TEntity : Entity, new()
{
    public GenericRepositoryEntity<TEntity> GenericRepositoryEntity { get; protected set; }
}

public interface IViewModele : IParam
{
}

public interface IViewModel<T> : IViewModele
    where T : IParam
{

}

public interface IViewModel<T, TEntity> : IViewModel<T>
    where T : IParam
    where TEntity : Entity, new()
{

}