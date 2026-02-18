using CSharpFunctionalExtensions;

namespace Admin.Args;

public record CardClickedArgs<TEntity>(TEntity Entity) where TEntity : Entity, new();
