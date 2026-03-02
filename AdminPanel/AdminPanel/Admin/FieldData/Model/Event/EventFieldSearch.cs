using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.Attribute;
using UserInterface.UiLayoutPanel.SearchCardPanel;

namespace Admin.FieldData.Model.Event
{
    public class EventFieldSearch(CategoryRepository repository) : SearchFieldData<EventEntity>
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

        public override Func<EventEntity[], EventEntity[]> SearchFunc =>
            entitys =>
                entitys
                    .Where(e => Category == null || Category.Equals(Categorys[0]) || e.Category.Equals(Category))
                    .Where(e => e.Title.StartsWith(Title ?? ""))
                    .Where(e =>
                        e.Schedule.DateT() >= StartDateTime() &&
                        e.Schedule.DateT() <= EndDateTime())
                    .ToArray();

        public override Action ClearFunc =>
            () =>
            {
                Category = string.Empty;
                StartDate = string.Empty;
                EndDate = string.Empty;
                Title = string.Empty;
            };
    }
}