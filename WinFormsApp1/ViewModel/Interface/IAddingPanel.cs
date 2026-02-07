using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IAddingPanel<T> : IViewData<T>
    where T : Entity, new()
{
    
}