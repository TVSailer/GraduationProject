using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using Logica.CustomAttribute;

namespace Admin.ViewModel.Model.Review;

public class ReviewFieldSearch : SearchFieldData
{
    [BaseFieldUi("Имя автора")]
    [FieldState("")]
    public string? NameVisitor { get; set => OnPropertyChange(ref field, value); } 
    
    [BaseFieldUi("Фамилия автора")]
    [FieldState("")]
    public string? SurnameVisitor { get; set => OnPropertyChange(ref field, value); }
}