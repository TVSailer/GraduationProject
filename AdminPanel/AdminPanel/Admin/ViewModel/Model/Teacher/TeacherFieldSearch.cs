using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;

namespace WinFormsApp1.ViewModel.Model.Teacher;

public class TeacherFieldSearch : PropertyChange, IFieldData
{
    [BaseFieldUi("Имя преподователя")]
    public string TeacherName
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";

    [BaseFieldUi("Фамилия преподователя")]
    public string TeacherSurname
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

