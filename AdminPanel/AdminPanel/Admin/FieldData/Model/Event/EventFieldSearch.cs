using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Repository;
using Logica.CustomAttribute;

namespace WinFormsApp1.ViewModelEntity.Event
{
    public class EventFieldSearch(EventCategoryRepository repository) : SearchFieldData
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
        public string? Title { get; set => OnPropertyChange(ref field, value); }

        [MaskedTextBoxFieldUi("с", "00/00/0000")]
        [FieldState("")]
        public string? StartDate { get; set => OnPropertyChange(ref field, value); }

        [MaskedTextBoxFieldUi("по", "00/00/0000")]
        [FieldState("")]
        public string? EndDate { get; set => OnPropertyChange(ref field, value); }

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
}