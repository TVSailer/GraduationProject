using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IViewData<TEntity> : IViewData
    where TEntity : Entity, new()
{
    GenericRepositoryEntity<TEntity> Entity { get; set; }
}

public interface IViewData
{
}