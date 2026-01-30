using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IViewModele<TEntity> : IViewModele
    where TEntity : Entity, new()
{
}

public interface IViewModele
{
}

public interface IViewModel<T> : IViewModele
{
}
