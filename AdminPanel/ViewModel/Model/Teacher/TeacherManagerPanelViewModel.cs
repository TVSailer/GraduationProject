using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using Ninject.Infrastructure.Language;

namespace Admin.ViewModel.Model.Teacher;

public class TeacherManagerPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<TeacherEntity> _repository;
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;
    public IEnumerable<TeacherEntity> Teachers { get; set; }

    public string? Name { get; set => Set(ref field, value, Search); }
    public string? Surname { get; set => Set(ref field, value, Search); }


    #region CommandClearSearch

    public readonly ICommand ClearSearch;

    public void ExecuteClearSearch(object? obj)
    {
        Name = string.Empty;
        Surname = string.Empty;
    }

    public bool CanExecuteClearSearch(object? obj)
    {
        return !string.IsNullOrEmpty(Name) ||
               !string.IsNullOrEmpty(Surname);
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
        _controlViewService.LoadView<TeacherAddingPanelViewModel>();
        Teachers = _repository.Get();
    }

    private bool CanExecuteLoadAddingPanel(object obj) => true;

    #endregion
    #region CommandLoadDetailsPanel

    internal readonly ICommand LoadDetailsPanel;

    private void ExecuteLoadDetailsPanel(object? obj)
    {
        _sharedService.SetData(obj);
        _controlViewService.LoadView<TeacherDetailsPanelViewModel>();
    }

    private bool CanExecuteLoadDetailsPanel(object? obj) => obj is TeacherEntity ? true : throw new ArgumentException();

    #endregion



    public TeacherManagerPanelViewModel(IRepository<TeacherEntity> repository, IControlViewService controlViewService, ISharedService sharedService)
    {
        Teachers = repository.Get().ToArray();

        _repository = repository;
        _controlViewService = controlViewService;
        _sharedService = sharedService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        ClearSearch = new ExecuteCommand(ExecuteClearSearch, CanExecuteClearSearch);
        LoadAddingPanel = new ExecuteCommand(ExecuteLoadAddingPanel, CanExecuteLoadAddingPanel);
        LoadDetailsPanel = new ExecuteCommand(ExecuteLoadDetailsPanel, CanExecuteLoadDetailsPanel);
    }

    private void Search() =>
        Teachers = _repository
            .Get()
            .ToEnumerable()
            .Where(e => e.Include(Name, Surname));
}
