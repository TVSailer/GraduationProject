using DataAccess.PostgreSQL.Models;
using UserInterface.Attribute;
using UserInterface.UiLayoutPanel.SearchCardPanel;

namespace Admin.FieldData.Model.Visitor;

public class  VisitorFieldSearch : SearchFieldData<VisitorEntity>
{
    [BaseFieldUi("Имя")]
    public string? VisitorName { get; set => OnPropertyChanged(ref field, value); }

    [BaseFieldUi("Фамилия")]
    public string? VisitorSurname { get; set => OnPropertyChanged(ref field, value); }

    public override Func<VisitorEntity[], VisitorEntity[]> SearchFunc =>
        entitys =>
            entitys
                .Where(e => e.FIO.Name.StartsWith(VisitorName ?? ""))
                .Where(e => e.FIO.Surname.StartsWith(VisitorSurname ?? ""))
                .ToArray();

    public override Action ClearFunc =>
        () =>
        {
            VisitorName = string.Empty;
            VisitorSurname = string.Empty;
        };
}