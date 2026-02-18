using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;

namespace Admin.ViewModel.Model.Review;

public class ReviewFieldSearch : PropertyChange, IFieldData
{
    [BaseFieldUi("Имя автора")]
    [FieldState("")]
    public string NameVisitor
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";
    
    [BaseFieldUi("Фамилия автора")]
    [FieldState("")]
    public string SurnameVisitor
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