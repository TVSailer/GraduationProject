using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorFieldSearch : PropertyChange, IFieldData
{
    [BaseFieldUi("Имя")]
    [FieldState("")]
    public string VisitorName
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";

    [BaseFieldUi("Фамилия")]
    [FieldState("")]
    public string VisitorSurname
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";
}