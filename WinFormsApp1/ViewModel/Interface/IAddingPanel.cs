using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IAddingPanel<T> : IViewModele<T>
    where T : Entity, new()
{
    
}