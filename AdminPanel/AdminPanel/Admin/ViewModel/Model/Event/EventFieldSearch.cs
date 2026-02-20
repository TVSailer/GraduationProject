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
        public EventCategoryEntity Category
        {
            get;
            set
            {
                if (value == field) return;
                field = value;
                OnPropertyChanged();
            }
        } = new("");

        [BaseFieldUi("Название")]
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
        public string? StartDate
        {
            get;
            set
            {
                if (value == field) return;

                field = value;
                OnPropertyChanged();
            }
        }
        
        [MaskedTextBoxFieldUi("по", "00/00/0000")]
        public string? EndDate
        {
            get;
            set
            {
                if (value == field) return;
                field = value;
                OnPropertyChanged();
            }
        } 
    }
}