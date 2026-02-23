using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using Logica.CustomAttribute;

namespace Admin.ViewModel.Model.Teacher;

public class TeacherFieldSearch : SearchFieldData
{
    [BaseFieldUi("Имя преподователя")]
    [FieldState("")]
    public string? TeacherName { get; set => OnPropertyChange(ref field, value); }

    [BaseFieldUi("Фамилия преподователя")]
    [FieldState("")]
    public string? TeacherSurname { get; set => OnPropertyChange(ref field, value); }
}
