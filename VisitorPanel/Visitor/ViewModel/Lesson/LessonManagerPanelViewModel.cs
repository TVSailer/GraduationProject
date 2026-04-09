using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;

namespace Visitor.ViewModel.Lesson;

public class LessonManagerPanelViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;
    private readonly IRepository<LessonEntity> _repositoryL;

    public IEnumerable<LessonEntity> LessonEntities => _repositoryL.Get().AsEnumerable();

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;

    private void ExecuteUpdate(object? obj) => _controlViewService.UpdateGui();
    private bool CanExecuteUpdate(object? obj) => true;

    #endregion
    #region CommandOpenLesson

    internal readonly ICommand OpenLesson;

    private void ExecuteOpenLesson(object? obj)
    {
        _sharedService.SetData(obj);
        _controlViewService.LoadView<LessonPanelViewModel>();
    }

    private bool CanExecuteOpenLesson(object? obj) => obj is LessonEntity ? true : throw new Exception();

    #endregion
    public LessonManagerPanelViewModel(
        IControlViewService controlViewService,
        ISharedService sharedService,
        IRepository<LessonEntity> repositoryL)
    {
        _controlViewService = controlViewService;
        _sharedService = sharedService;
        _repositoryL = repositoryL;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        OpenLesson = new ExecuteCommand(ExecuteOpenLesson, CanExecuteOpenLesson);
    }
}