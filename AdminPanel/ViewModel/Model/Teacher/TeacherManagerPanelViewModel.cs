using Admin.ViewModel.Model.Event;
using Domain.Entitys;
using Domain.Repository;
using Ninject.Infrastructure.Language;
using System.Windows.Input;
using General.Service.ControlView.BaseControlView;

namespace Admin.FieldData.Model.Teacher;

public class TeacherManagerPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<TeacherEntity> _repository;
    private readonly IControlViewService _controlViewService;
    public IEnumerable<TeacherEntity> Teachers { get; set; }

    public string? Name { get; set => Set(ref field, value); }
    public string? Surname { get; set => Set(ref field, value); }


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
        Teachers = _repository.Get();
        _controlViewService.LoadView<EventAddingPanelViewModel>();
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



    public TeacherManagerPanelViewModel(IRepository<TeacherEntity> repository, IControlViewService controlViewService)
    {
        _repository = repository;
        _controlViewService = controlViewService;
    }

    private void Search() =>
        Teachers = _repository
            .Get()
            .ToEnumerable()
            .Where(e => e.Include(Name, Surname));
}
