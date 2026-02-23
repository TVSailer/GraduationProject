using System.Runtime.CompilerServices;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.ViewModel.AbstractViewModel;

public class SearchFieldData : PropertyChange, IFieldData
{
    public void OnPropertyChange<T>(ref T field, T value, [CallerMemberName] string pr = "")
    {
        if (value != null && value.Equals(field)) return;
        field = value;
        OnPropertyChanged(pr);
    }
}