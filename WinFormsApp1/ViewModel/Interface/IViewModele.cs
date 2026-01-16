using CSharpFunctionalExtensions;

public interface IViewModele<TEntity> : IViewModele
    where TEntity : Entity
{
    public TEntity Entity { get; set; }
}

