using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;
using Domain.Command;
using Visitor.ViewModel.Enter;
using Visitor.ViewModel.Event;
using Visitor.ViewModel.Lesson;
using Visitor.ViewModel.News;
using Visitor.ViewModel.Visitor;

namespace Visitor.ViewModel.Main;

public class MainPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;

    #region CommandOpenProfel

    internal readonly ICommand OpenProfel;

    private void ExecuteOpenProfel(object? obj) => _controlViewService.LoadView<VisitorProfelPanelViewModel>();
    private bool CanExecuteOpenProfel(object? obj) => true;

    #endregion
    #region CommandOpenEnter

    internal readonly ICommand OpenEnter;

    private void ExecuteOpenEnter(object? obj) => _controlViewService.ShowDialog<EnterPanelViewModel>();
    private bool CanExecuteOpenEnter(object? obj) => true;

    #endregion
    #region CommandOpenLesson

    internal readonly ICommand OpenLesson;

    private void ExecuteOpenLesson(object? obj) => _controlViewService.LoadView<LessonManagerPanelViewModel>();
    private bool CanExecuteOpenLesson(object? obj) => true;

    #endregion
    #region CommandOpenNews

    internal readonly ICommand OpenNews;

    private void ExecuteOpenNews(object? obj) => _controlViewService.LoadView<NewsManagerPanelViewModel>();
    private bool CanExecuteOpenNews(object? obj) => true;

    #endregion
    #region CommandOpenEvent

    internal readonly ICommand OpenEvent;

    private void ExecuteOpenEvent(object? obj) => _controlViewService.LoadView<EventManagerPanelViewModel>();
    private bool CanExecuteOpenEvent(object? obj) => true;

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public MainPanelViewModel(
        IControlViewService controlViewService,
        ISharedService sharedService
        )
    {
        _controlViewService = controlViewService;
        _sharedService = sharedService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        OpenEnter = new ExecuteCommand(ExecuteOpenEnter, CanExecuteOpenEnter);
        OpenEvent = new ExecuteCommand(ExecuteOpenEvent, CanExecuteOpenEvent);
        OpenProfel = new ExecuteCommand(ExecuteOpenProfel, CanExecuteOpenProfel);
        OpenNews = new ExecuteCommand(ExecuteOpenNews, CanExecuteOpenNews);
        OpenLesson = new ExecuteCommand(ExecuteOpenLesson, CanExecuteOpenLesson);
    }
}
