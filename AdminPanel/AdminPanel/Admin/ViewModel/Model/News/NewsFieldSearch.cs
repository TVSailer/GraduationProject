using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Repository;
using Logica.CustomAttribute;

namespace Admin.ViewModel.Model.News;

public class NewsFieldSearch(NewsCategoryRepository repository) : SearchFieldData
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
    public string Category { get; set => OnPropertyChange(ref field, value); } = "";

    [BaseFieldUi("Название")]
    [FieldState("")]
    public string Title { get; set => OnPropertyChange(ref field, value); } = "";
    
    [BaseFieldUi("Автор")]
    [FieldState("")]
    public string Author { get; set => OnPropertyChange(ref field, value); } = "";

    [MaskedTextBoxFieldUi("с", "00/00/0000")]
    [FieldState("")]
    public string? StartDate { get; set => OnPropertyChange(ref field, value); } = "";

    [MaskedTextBoxFieldUi("по", "00/00/0000")]
    [FieldState("")]
    public string? EndDate { get; set => OnPropertyChange(ref field, value); } = "";

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
}