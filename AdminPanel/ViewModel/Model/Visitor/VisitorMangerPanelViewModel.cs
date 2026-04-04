using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorManagerPanelViewModel : General.ViewModel.ViewModel
{

    private readonly IRepository<VisitorEntity> _repositoryV;
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;

    public IEnumerable<VisitorEntity> VisitorEntities { get; private set => Set(ref field, value); }

    public string? Name { get; set => Set(ref field, value, Search); }
    public string? Surname { get; set => Set(ref field, value, Search); }
    public string? StartYear { get; set => Set(ref field, value, Search); } = "0";
    public string? EndYear { get; set => Set(ref field, value, Search); } = "0";

    #region CommandClearSearch

    public readonly ICommand ClearSearch;

    public void ExecuteClearSearch(object? obj)
    {
        if (!CanExecuteClearSearch(obj)) return;
        Name = string.Empty;
        Surname = string.Empty;
        StartYear = "0"; ;
        EndYear = "0"; ;
    }

    public bool CanExecuteClearSearch(object? obj)
    {
        return !string.IsNullOrEmpty(Name) ||
               !string.IsNullOrEmpty(Surname) ||
               StartYear is not "0" ||
               EndYear is not "0";
    }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object obj) => true;

    #endregion
    #region CommandLoadDetailsPanel

    internal readonly ICommand LoadDetailsPanel;

    private void ExecuteLoadDetailsPanel(object? obj)
    {
        _sharedService.SetData(obj);
        _controlViewService.LoadView<VisitorDetailsPanelViewModel>();
        VisitorEntities = _repositoryV.Get();
    }

    private bool CanExecuteLoadDetailsPanel(object? obj) => obj is VisitorEntity ? true : throw new ArgumentException();

    #endregion

    public VisitorManagerPanelViewModel(
        IRepository<VisitorEntity> repositoryV,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        VisitorEntities = repositoryV.Get().ToArray();

        _repositoryV = repositoryV;
        _controlViewService = controlViewService;
        _sharedService = sharedService;

        ClearSearch = new ExecuteCommand(ExecuteClearSearch, CanExecuteClearSearch);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        LoadDetailsPanel = new ExecuteCommand(ExecuteLoadDetailsPanel, CanExecuteLoadDetailsPanel);
    }

    private void Search() =>
        VisitorEntities = _repositoryV
            .Get()
            .AsEnumerable()
            .Where(e => e.Include(Name, Surname, int.Parse(StartYear), int.Parse(EndYear)));

}