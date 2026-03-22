using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Attribute;
using UserInterface.UiLayoutPanel.SearchCardPanel;

namespace Admin.FieldData.Model.News;

public class NewsFieldSearch(CategoryRepository repository) : SearchFieldData<NewsEntity>
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
    public string? Title { get; set => OnPropertyChanged(ref field, value); } 
    
    [BaseFieldUi("Автор")]
    public string? Author { get; set => OnPropertyChanged(ref field, value); }

    [MaskedTextBoxFieldUi("с", "00/00/0000")]
    public string? StartDate { get; set => OnPropertyChanged(ref field, value); }

    [MaskedTextBoxFieldUi("по", "00/00/0000")]
    public string? EndDate { get; set => OnPropertyChanged(ref field, value); }

    public DateTime StartDateTime()
    {
        if (DateTime.TryParse(StartDate, out var date))
            return date;
        return DateTime.MinValue;
    }

    public DateTime EndDateTime()
    {
        if (DateTime.TryParse(EndDate, out var date))
            return date;
        return DateTime.MaxValue;
    }

    public override Func<NewsEntity[], NewsEntity[]> SearchFunc =>
        entitys =>
            entitys
                .Where(e => Category == null || Category.Equals(Categorys[0]) || e.Category.Equals(Category))
                .Where(e => e.Title.StartsWith(Title ?? ""))
                .Where(e => e.Author.StartsWith(Author ?? ""))
                .Where(e =>
                    e.DateT() >= StartDateTime() &&
                    e.DateT() <= EndDateTime())
                .ToArray();

    public override Action ClearFunc =>
        () =>
        {
            Category = string.Empty;
            Title = string.Empty;
            Author = string.Empty;
            EndDate = string.Empty;
            StartDate = string.Empty;
        };
}