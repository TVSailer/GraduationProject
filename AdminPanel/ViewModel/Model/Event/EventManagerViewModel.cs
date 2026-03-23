using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Event
{
    public class EventManagerViewModel : Abstract.ViewModel.ViewModel
    {
        public readonly EventEntity[] EventsEntities;
        public readonly List<string> CategoryModels = [""];

        public string? Category { get; set => Set(ref field, value); }
        public string? Title { get; set => Set(ref field, value); }
        public string? StartDate { get; set => Set(ref field, value); }
        public string? EndDate { get; set => Set(ref field, value); }

        #region CommandClearSearch

        public readonly ICommand ClearSearch;

        public void ExecuteClearSearch(object? obj)
        {
            if (!CanExecuteClearSearch(obj)) return;
            Category = string.Empty;
            StartDate = string.Empty;
            EndDate = string.Empty;
            Title = string.Empty;
        }
        
        public bool CanExecuteClearSearch(object? obj)
        {
            return !string.IsNullOrEmpty(Category) ||
                   !string.IsNullOrEmpty(StartDate) ||
                   !string.IsNullOrEmpty(EndDate) ||
                   !string.IsNullOrEmpty(Title);
        }

        #endregion

        #region SerchFunc

        public Func<EventEntity[]> SearchFunc =>
            () => EventsEntities
                .Where(e => Category == null || Category.Equals("") || Category.Equals(e.Category))
                .Where(e => e.Title.StartsWith(Title ?? ""))
                .Where(e => DateTime.Parse(e.Schedule.Date) >= (DateTime.TryParse(StartDate , out var dateS) ? dateS : DateTime.MinValue) &&
                            DateTime.Parse(e.Schedule.Date) <= (DateTime.TryParse(EndDate, out var dateE) ? dateE : DateTime.MaxValue))
                .ToArray();

        #endregion

        public EventManagerViewModel(IRepository<CategoryEntity> repositoryC, IRepository<EventEntity> repositoryE)
        {
            EventsEntities = repositoryE.Get().ToArray();
            CategoryModels.AddRange(repositoryC.Get().Select(c => c.Category));

            ClearSearch = new ExecuteCommand(ExecuteClearSearch);
        }
    }
}