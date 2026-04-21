using System.Windows.Input;
using Admin.ViewModel.Event;
using Admin.ViewModel.Lesson;
using Admin.ViewModel.News;
using Admin.ViewModel.Teacher;
using Admin.ViewModel.Visitor;
using Domain.Command;
using Domain.Service.ControlViewService.BaseControlView;

namespace Admin.ViewModel.AdminMain;

public class AdminPanelViewModel
{
    private readonly IControlViewService _controlViewService;

    #region CommandLoadEventManagerPanelView

    internal readonly ICommand LoadEventManagerPanelView;

    private void ExecuteLoadEventManagerPanelView(object? obj) => _controlViewService.LoadView<EventManagerPanelViewModel>();
    private bool CanExecuteLoadEventManagerPanelView(object? obj) => true;

    #endregion
    #region CommandLoadTeacherManagerPanelView

    internal readonly ICommand LoadTeacherManagerPanelView;

    private void ExecuteLoadTeacherManagerPanelView(object? obj) => _controlViewService.LoadView<TeacherManagerPanelViewModel>();
    private bool CanExecuteLoadTeacherManagerPanelView(object? obj) => true;

    #endregion
    #region CommandLoadNewsManagerPanelView

    internal readonly ICommand LoadNewsManagerPanelView;

    private void ExecuteLoadNewsManagerPanelView(object? obj) => _controlViewService.LoadView<NewsManagerPanelViewModel>();
    private bool CanExecuteLoadNewsManagerPanelView(object? obj) => true;

    #endregion
    #region CommandLoadLessonManagerPanelView

    internal readonly ICommand LoadLessonManagerPanelView;

    private void ExecuteLoadLessonManagerPanelView(object? obj) => _controlViewService.LoadView<LessonManagerPanelViewModel>();
    private bool CanExecuteLoadLessonManagerPanelView(object? obj) => true;
    #endregion
    #region CommandLoadVisitorManagerPanelView

    internal readonly ICommand LoadVisitorManagerPanelView;

    private void ExecuteLoadVisitorManagerPanelView(object? obj) => _controlViewService.LoadView<VisitorManagerPanelViewModel>();
    private bool CanExecuteLoadVisitorManagerPanelView(object? obj) => true;

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public AdminPanelViewModel(IControlViewService controlViewService)
    {
        _controlViewService = controlViewService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        LoadEventManagerPanelView = new ExecuteCommand(ExecuteLoadEventManagerPanelView, CanExecuteLoadEventManagerPanelView);
        LoadTeacherManagerPanelView = new ExecuteCommand(ExecuteLoadTeacherManagerPanelView, CanExecuteLoadTeacherManagerPanelView);
        LoadLessonManagerPanelView = new ExecuteCommand(ExecuteLoadLessonManagerPanelView, CanExecuteLoadLessonManagerPanelView);
        LoadVisitorManagerPanelView = new ExecuteCommand(ExecuteLoadVisitorManagerPanelView, CanExecuteLoadVisitorManagerPanelView);
        LoadNewsManagerPanelView = new ExecuteCommand(ExecuteLoadNewsManagerPanelView, CanExecuteLoadNewsManagerPanelView);
    }
}