using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using User_Interface_Library.Attribute;
using User_Interface_Library.UiLayoutPanel.SearchCardPanel;

namespace Admin.ViewModels.Lesson;

public class LessonFieldSearch(Repository<CategoryEntity> repository) : SearchFieldData<LessonEntity>
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
    public string? Category { get; set => OnPropertyChanged(ref field, value); } 

    [BaseFieldUi("Название")]
    public string? Name { get; set => OnPropertyChanged(ref field, value); }

    [BaseFieldUi("Имя преподователя")]
    public string? TeacherName { get; set => OnPropertyChanged(ref field, value); }

    [BaseFieldUi("Фамилия преподователя")]
    public string? TeacherSurname { get; set => OnPropertyChanged(ref field, value); }

    public override Action ClearFunc => 
        () =>
        {
            Name = "";
            Category = "";
            TeacherName = "";
            TeacherSurname = "";
        };

    public override Func<LessonEntity[], LessonEntity[]> SearchFunc =>
        entitys =>
            entitys
                .Where(e => Category == null || Category.Equals("") || e.Category.Equals(Category))
                .Where(e => e.Name.StartsWith(Name ?? ""))
                .Where(e => e.Teacher.FIO.Name.StartsWith(TeacherName ?? ""))
                .Where(e => e.Teacher.FIO.Surname.StartsWith(TeacherSurname ?? ""))
                .ToArray();
}