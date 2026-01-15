using CSharpFunctionalExtensions;

public interface IViewModele<TEntity>
    where TEntity : Entity
{
    public TEntity Entity { get; set; }
}

