using CSharpFunctionalExtensions;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Event
{
    public class EventManagerPanelViewModel : General.ViewModel.ViewModel
    {
        private readonly IRepository<EventEntity> _repositoryE;
        private readonly IControlViewService _controlViewService;
        private readonly ISharedService _sharedService;

        public IEnumerable<EventEntity> EventsEntities { get; private set => Set(ref field, value); }
        public CategoryEntity[] CategoryEntities;

        public string? Category { get; set => Set(ref field, value, Search); }
        public string? Title { get; set => Set(ref field, value, Search); }
        public string? StartDate { get; set => Set(ref field, value, Search); }
        public string? EndDate { get; set => Set(ref field, value, Search); }

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
        #region CommandExit

        internal readonly ICommand Exit;

        private void ExecuteExit(object obj) => _controlViewService.Exit();
        private bool CanExecuteExit(object obj) => true;

        #endregion
        #region CommandLoadAddingPanel

        internal readonly ICommand LoadAddingPanel;

        private void ExecuteLoadAddingPanel(object obj)
        {
            _controlViewService.LoadView<EventAddingPanelViewModel>();
            EventsEntities = _repositoryE.Get();
        }

        private bool CanExecuteLoadAddingPanel(object obj) => true;

        #endregion
        #region CommandLoadDetailsPanel

        internal readonly ICommand LoadDetailsPanel;

        private void ExecuteLoadDetailsPanel(object? obj)
        {
            _sharedService.SetData(obj);
            _controlViewService.LoadView<EventDetailsPanelViewModel>();
            EventsEntities = _repositoryE.Get();
        }

        private bool CanExecuteLoadDetailsPanel(object? obj) => obj is EventEntity ? true : throw new ArgumentException();

        #endregion

        public EventManagerPanelViewModel(
            IRepository<CategoryEntity> repositoryC, 
            IRepository<EventEntity> repositoryE, 
            IControlViewService controlViewService,
            ISharedService sharedService)
        {
            EventsEntities = repositoryE.Get().ToArray();
            CategoryEntities = repositoryC.Get().ToArray();

            _repositoryE = repositoryE;
            _controlViewService = controlViewService;
            _sharedService = sharedService;

            ClearSearch = new ExecuteCommand(ExecuteClearSearch, CanExecuteClearSearch);
            Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
            LoadAddingPanel = new ExecuteCommand(ExecuteLoadAddingPanel, CanExecuteLoadAddingPanel);
            LoadDetailsPanel = new ExecuteCommand(ExecuteLoadDetailsPanel, CanExecuteLoadDetailsPanel);
        }

        private void Search() =>
            EventsEntities = _repositoryE
                .Get()
                .AsEnumerable()
                .Where(e => e.Include(Category, Title, StartDate, EndDate));
    }
}