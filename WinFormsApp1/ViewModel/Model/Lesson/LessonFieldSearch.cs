using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModels.Lesson;

public class LessonFieldSearch(Repository<LessonCategoryEntity> repository) : PropertyChange, IFieldData
{
    public List<string> category
    {
        get
        {
            var list = new List<string>();
            list.Add("");
            repository.Get().Select(c => c.Category).ForEach(t => list.Add(t));
            return list;
        }
    }

    [ComboBoxFieldUi("Категория", nameof(category))]
    [FieldState("")]
    public string Category
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";

    [BaseFieldUi("Название")]
    [FieldState("")]
    public string Name
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";

    [BaseFieldUi("Имя преподователя")]
    [FieldState("")]
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
    [FieldState("")]
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