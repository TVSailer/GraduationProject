using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;

namespace WinFormsApp1.ViewModelEntity.Event
{
    public class EventFieldSearch(EventCategoryRepository repository) : PropertyChange, IFieldData
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
        public string Title
        {
            get;
            set
            {
                if (value == field) return;
                field = value;
                OnPropertyChanged();
            }
        } = "";

        [MaskedTextBoxFieldUi("с", "00/00/0000")]
        [FieldState("")]
        public string? StartDate
        {
            get;
            set
            {
                if (value == field) return;

                field = value;
                OnPropertyChanged();
            }
        } = "";

        [MaskedTextBoxFieldUi("по", "00/00/0000")]
        [FieldState("")]
        public string? EndDate
        {
            get;
            set
            {
                if (value == field) return;
                field = value;
                OnPropertyChanged();
            }
        } = "";

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