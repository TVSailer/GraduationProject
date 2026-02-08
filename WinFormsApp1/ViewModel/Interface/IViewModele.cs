using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IFieldData<TEntity> : IFieldData
    where TEntity : Entity, new()
{
    GenericRepositoryEntity<TEntity> Entity { get; set; }
}
