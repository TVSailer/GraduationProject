using UserInterface.Attribute;
using UserInterface.UiLayoutPanel.SearchCardPanel;

namespace Admin.FieldData.Model.Review;

public class ReviewFieldSearch : SearchFieldData<ReviewEntity>
{
    [BaseFieldUi("Имя автора")]
    public string? NameVisitor { get; set => OnPropertyChanged(ref field, value); } 
    
    [BaseFieldUi("Фамилия автора")]
    public string? SurnameVisitor { get; set => OnPropertyChanged(ref field, value); }

    public override Func<ReviewEntity[], ReviewEntity[]> SearchFunc =>
        entitys =>
            entitys
                .Where(e => e.Visitor.FIO.Name.StartsWith(NameVisitor ?? ""))
                .Where(e => e.Visitor.FIO.Surname.StartsWith(SurnameVisitor ?? ""))
                .ToArray();

    public override Action ClearFunc =>
        () =>
        {
            NameVisitor = string.Empty;
            SurnameVisitor = string.Empty;
        };
}