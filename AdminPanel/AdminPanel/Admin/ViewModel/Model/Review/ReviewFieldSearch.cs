using Admin.View.Moduls.Visitor;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Model.Lesson.Buttons;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica.Interface;

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