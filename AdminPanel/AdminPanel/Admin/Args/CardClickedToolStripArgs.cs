using CSharpFunctionalExtensions;

namespace Admin.Args;

public record CardClickedToolStripArgs<TEntity>(TEntity Entity) where TEntity : Entity, new();