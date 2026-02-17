using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.Args;

public record ViewButtonClickArgs<TEntity, TField>(TField FieldData) 
    where TField : IFieldData<TEntity>
    where TEntity : Entity, new();

public record ViewButtonClickArgs<TField>(TField FieldData) where TField : IFieldData;