using Admin.ViewModel.Model.Event;
using Domain.Entitys;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;
using Domain.Command;
using Domain.Repository;

namespace Admin.ViewModel.Model.Review;

public class ReviewManagerViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IRepository<ReviewEntity> _repositoryR;
    private readonly ISharedService _sharedService;
    private readonly LessonEntity _lessonEntity;

    public IEnumerable<ReviewEntity> ReviewEntities { get; private set => Set(ref field, value); }

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
        _controlViewService.LoadView<ReviewDetailsPanelViewModel>();
        ReviewEntities = _repositoryR.Get().Where(r => r.Lesson.Id.Equals(_lessonEntity.Id));
    }

    private bool CanExecuteLoadDetailsPanel(object? obj) => obj is ReviewEntity ? true : throw new ArgumentException();

    #endregion

    public ReviewManagerViewModel(
        IControlViewService controlViewService,
        IRepository<ReviewEntity> repositoryR,
        ISharedService sharedService
        )
    {
        _lessonEntity = sharedService.GetData<LessonEntity>();
        ReviewEntities = _lessonEntity.Reviews;

        _controlViewService = controlViewService;
        _repositoryR = repositoryR;
        _sharedService = sharedService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        LoadDetailsPanel = new ExecuteCommand(ExecuteLoadDetailsPanel, CanExecuteLoadDetailsPanel);
    }
}