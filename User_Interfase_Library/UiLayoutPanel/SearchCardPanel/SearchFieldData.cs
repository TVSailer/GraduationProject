using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UserInterface.UiLayoutPanel.SearchCardPanel;

public abstract class SearchFieldData<T>
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public abstract Func<T[], T[]> SearchFunc { get; }
    public abstract Action ClearFunc { get; }
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public void OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string pr = "")
    {
        if (value != null && value.Equals(field)) return;
        field = value;
        OnPropertyChanged(pr);
    }
}