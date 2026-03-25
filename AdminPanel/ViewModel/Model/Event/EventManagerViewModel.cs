using Castle.Core.Internal;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using System.Windows.Input;
using UserInterface.Service.View.Base;

namespace Admin.ViewModel.Model.Event
{
    public class EventManagerPanelViewModel : General.ViewModel.ViewModel
    {
        private readonly IControlView _controlView;
        public readonly EventEntity[] EventsEntities;
        public readonly CategoryEntity[]? CategoryEntities;

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
        #region CommandExit

        internal readonly ICommand Exit;

        private void ExecuteExit(object obj) => _controlView.Exit();
        private bool CanExecuteExit(object obj) => true;

        #endregion
        #region CommandLoadAddingPanel

        internal readonly ICommand LoadAddingPanel;

        private void ExecuteLoadAddingPanel(object obj) => _controlView.LoadView<EventAddingPanelViewModel>();
        private bool CanExecuteLoadAddingPanel(object obj) => CategoryEntities.IsNullOrEmpty();

        #endregion
        
        public EventManagerPanelViewModel(IRepository<CategoryEntity> repositoryC, IRepository<EventEntity> repositoryE, IControlView controlView)
        {
            _controlView = controlView;
            EventsEntities = repositoryE.Get().ToArray();
            CategoryEntities = repositoryC.Get().ToArray();

            ClearSearch = new ExecuteCommand(ExecuteClearSearch);
            Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
            LoadAddingPanel = new ExecuteCommand(ExecuteLoadAddingPanel, CanExecuteLoadAddingPanel);
        }
    }
}