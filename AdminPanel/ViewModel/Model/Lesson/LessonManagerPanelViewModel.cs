using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Lesson;

public class LessonManagerPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;

    public IEnumerable<LessonEntity> Learches { get; private set => Set(ref field, value); }
    public readonly CategoryEntity[] CategoryEntities;

    public string? Category { get; set => Set(ref field, value, Search); }
    public string? Title { get; set => Set(ref field, value, Search); }
    public string? TeacherName { get; set => Set(ref field, value, Search); }
    public string? TeacherSurname { get; set => Set(ref field, value, Search); }

    //new InfoToolStrip("Управление поситителями").CommandClick(() => ControlLesson<VisitorBelongingLesson>(eventToolStripArgs?.Data)),
    //new InfoToolStrip("Управление посещаемостью").CommandClick(() => ControlLesson<DateAttendanceManager>(eventToolStripArgs?.Data)),
    //new InfoToolStrip("Управление отзывами").CommandClick(() => ControlLesson<ReviewManager>(eventToolStripArgs?.Data)),


    #region CommandClearSearch

    public readonly ICommand ClearSearch;

    public void ExecuteClearSearch(object? obj)
    {
        if (!CanExecuteClearSearch(obj)) return;
        Category = string.Empty;
        TeacherName = string.Empty;
        TeacherSurname = string.Empty;
        Title = string.Empty;
    }

    public bool CanExecuteClearSearch(object? obj)
    {
        return !string.IsNullOrEmpty(Category) ||
               !string.IsNullOrEmpty(TeacherName) ||
               !string.IsNullOrEmpty(TeacherSurname) ||
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
        _controlViewService.LoadView<LessonAddingPanelViewModel>();
        Learches = _repositoryL.Get();
    }

    private bool CanExecuteLoadAddingPanel(object obj) => CategoryEntities is not null;

    #endregion
    #region CommandLoadDetailsPanel

    internal readonly ICommand LoadDetailsPanel;

    private void ExecuteLoadDetailsPanel(object? obj)
    {
        _sharedService.SetData(obj);
        _controlViewService.LoadView<LessonDetailsPanelViewModel>();
        Learches = _repositoryL.Get();
    }

    private bool CanExecuteLoadDetailsPanel(object? obj) => obj is LessonEntity ? true : throw new ArgumentException();

    #endregion

    public LessonManagerPanelViewModel(
        IRepository<LessonEntity> repositoryL, 
        IRepository<CategoryEntity> repositoryC,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        CategoryEntities = repositoryC.Get().ToArray();
        Learches = repositoryL.Get().ToArray();

        _repositoryL = repositoryL;
        _controlViewService = controlViewService;
        _sharedService = sharedService;

        ClearSearch = new ExecuteCommand(ExecuteClearSearch, CanExecuteClearSearch);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        LoadAddingPanel = new ExecuteCommand(ExecuteLoadAddingPanel, CanExecuteLoadAddingPanel);
        LoadDetailsPanel = new ExecuteCommand(ExecuteLoadDetailsPanel, CanExecuteLoadDetailsPanel);
    }

    public void Search()
        => Learches = _repositoryL
            .Get()
            .AsEnumerable()
            .Where(l => l.Include(Title, Category, TeacherName, TeacherSurname));
}