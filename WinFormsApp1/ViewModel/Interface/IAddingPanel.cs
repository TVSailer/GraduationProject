using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IAddingPanel<T> : IViewModele<T>, IParam
    where T : Entity, new()
{
    
}