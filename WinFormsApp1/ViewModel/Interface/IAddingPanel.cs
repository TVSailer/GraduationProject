using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Interface;

public interface IAddingPanel<T> : IFieldData<T>
    where T : Entity, new()
{
    
}