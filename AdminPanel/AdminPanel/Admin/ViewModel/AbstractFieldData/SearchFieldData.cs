using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.ViewModel.AbstractViewModel;

public class SearchFieldData : PropertyChange, IFieldData
{
    public void OnPropertyChange<T>(ref T field, T value)
    {
        if (value.Equals(field)) return;
        field = value;
        OnPropertyChanged();
    }
}