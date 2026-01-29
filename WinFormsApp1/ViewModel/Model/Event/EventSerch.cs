using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace WinFormsApp1.ViewModelEntity.Event
{
    public class EventSerch : SerchManagment<EventEntity>
    {
        public List<EventCategoryEntity> category = [new("")];

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

        public EventSerch(Repository<EventEntity> repository, Repository<EventCategoryEntity> repositoryCategory) : base(repository)
        {
            repositoryCategory.Get().ForEach(c => category.Add(c));

            OnClearSerchFunk = () =>
            {
                StartDate = null;
                EndDate = null;
                Title = "";
                Category = category[0];
            };

            OnSerhFunk = (entitys) =>
            {
                return entitys
                    .Where(e => Category.Equals(category[0]) || e.Category.Equals(Category))
                    .Where(e => e.Title.StartsWith(Title))
                    .Where(e => 
                        !DateTime.TryParse(StartDate, out _) || !DateTime.TryParse(EndDate, out _) || 
                        DateTime.Parse(e.Schedule.Date) >= DateTime.Parse(StartDate) && 
                        DateTime.Parse(e.Schedule.Date) <= DateTime.Parse(EndDate))
                    .ToList();
            };
        }

        public override Func<List<EventEntity>, List<EventEntity>> OnSerhFunk { get; protected set; }
        public override Action OnClearSerchFunk { get; protected set; }
    }
}
