using CSharpFunctionalExtensions;

public interface IViewModele<TEntity> : IViewModele
    where TEntity : Entity, new()
{
    public GenericRepositoryEntity<TEntity> GenericRepositoryEntity { get; protected set; }
}

