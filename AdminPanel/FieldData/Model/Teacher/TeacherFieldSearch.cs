using DataAccess.PostgreSQL.Models;
using UserInterface.Attribute;
using UserInterface.UiLayoutPanel.SearchCardPanel;

namespace Admin.FieldData.Model.Teacher;

public class TeacherFieldSearch : SearchFieldData<TeacherEntity>
{

    [BaseFieldUi("Имя преподователя")]
    public string? TeacherName { get; set => OnPropertyChanged(ref field, value); }

    [BaseFieldUi("Фамилия преподователя")]
    public string? TeacherSurname { get; set => OnPropertyChanged(ref field, value); }

    public override Func<TeacherEntity[], TeacherEntity[]> SearchFunc =>
        entitys =>
            entitys
                .Where(e => e.FIO.Name.StartsWith(TeacherName ?? ""))
                .Where(e => e.FIO.Surname.StartsWith(TeacherSurname ?? ""))
                .ToArray();

    public override Action ClearFunc =>
        () =>
        {
            TeacherName = string.Empty;
            TeacherSurname = string.Empty;
        };
}
