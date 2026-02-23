using Admin.ViewModel.AbstractViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.CustomAttribute;

namespace Admin.ViewModels.Lesson;

public class LessonFieldSearch(Repository<LessonCategoryEntity> repository) : SearchFieldData
{
    public List<string> Categorys
    {
        get
        {
            var list = new List<string> { "" };
            list.AddRange(repository.Get().Select(c => c.Category));
            return list;
        }
    }

    [ComboBoxFieldUi("Категория", nameof(Categorys))]
    [FieldState("")]
    public string? Category { get; set => OnPropertyChange(ref field, value); } 

    [BaseFieldUi("Название")]
    [FieldState("")]
    public string? Name { get; set => OnPropertyChange(ref field, value); }

    [BaseFieldUi("Имя преподователя")]
    [FieldState("")]
    public string? TeacherName { get; set => OnPropertyChange(ref field, value); }

    [BaseFieldUi("Фамилия преподователя")]
    [FieldState("")]
    public string? TeacherSurname { get; set => OnPropertyChange(ref field, value); }
}