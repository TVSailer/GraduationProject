using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.Memento;

public class MementoStateField<T>
    where T : IFieldData
{
    public T? State { get; set; }
}
