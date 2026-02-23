using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using Logica.CustomAttribute;
using Logica.Interface;

namespace Admin.ViewModel.Model.Visitor;

public class  VisitorFieldSearch : SearchFieldData
{
    [BaseFieldUi("Имя")]
    [FieldState("")]
    public string? VisitorName { get; set => OnPropertyChange(ref field, value); }

    [BaseFieldUi("Фамилия")]
    [FieldState("")]
    public string? VisitorSurname { get; set => OnPropertyChange(ref field, value); } 
}