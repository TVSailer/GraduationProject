using CSharpFunctionalExtensions;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Ninject.Infrastructure.Language;
using System.Windows.Input;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using UserInterface.Service.View.Base;

namespace Admin.ViewModel.Model.Event
{
    public class EventManagerPanelViewModel : General.ViewModel.ViewModel
    {
        private readonly IRepository<CategoryEntity> _repositoryC;
        private readonly IRepository<EventEntity> _repositoryE;
        private readonly IControlViewService _controlViewService;
        private readonly ISharedService _sharedService;

        public IEnumerable<EventEntity> EventsEntities { get; set; }
        public CategoryEntity[] CategoryEntities => _repositoryC.Get().ToArray();

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

        private bool CanExecuteLoadAddingPanel(object obj) => CategoryEntities is not null;

        #endregion
        #region CommandLoadDetailsPanel

        internal readonly ICommand LoadDetailsPanel;

        private void ExecuteLoadDetailsPanel(object? obj)
        {
            _sharedService.SetData(obj);
            _controlViewService.LoadView<EventDetailsPanelViewModel>();
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

            _repositoryC = repositoryC;
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
                .ToEnumerable()
                .Where(e => e.Include(Category, Title, StartDate, EndDate));
    }
}