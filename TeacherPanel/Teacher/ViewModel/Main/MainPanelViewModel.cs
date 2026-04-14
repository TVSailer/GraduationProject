using Domain.Command;
using Domain.Entitys;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MementoService.BaseMementoService;
using System.Windows.Input;
using Domain.Enum;
using Domain.Service.MessageService.BaseMessageService;
using Teacher.ViewModel.Enter;
using Teacher.ViewModel.Event;
using Teacher.ViewModel.Lesson;
using Teacher.ViewModel.News;
using Teacher.ViewModel.Teacher;

namespace Teacher.ViewModel.Main;

public class MainPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IMessageService _messageService;
    private readonly IMementoService<TeacherEntity> _mementoService;

    #region CommandOpenEnter

    internal readonly ICommand OpenEnter;

    private void ExecuteOpenEnter(object? obj)
    {
        if (_mementoService.Get().HasValue)
        {
            _controlViewService.LoadView<TeacherProfelPanelViewModel>();
            return;
        }

        _controlViewService.ShowDialog<EnterPanelViewModel>();
    }

    private bool CanExecuteOpenEnter(object? obj) => true;

    #endregion
    #region CommandOpenLesson

    internal readonly ICommand OpenLesson;

    private void ExecuteOpenLesson(object? obj) => _controlViewService.LoadView<LessonManagerPanelViewModel>();
    private bool CanExecuteOpenLesson(object? obj)
    {
        if (_mementoService.Get().HasValue) return true;
        _messageService.Message("Выполните вход в аккаунт", TypeMessage.Info);
        return false;
    }

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
        IMessageService messageService,
        IMementoService<TeacherEntity> mementoService)
    {
        _controlViewService = controlViewService;
        _messageService = messageService;
        _mementoService = mementoService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        OpenEnter = new ExecuteCommand(ExecuteOpenEnter, CanExecuteOpenEnter);
        OpenEvent = new ExecuteCommand(ExecuteOpenEvent, CanExecuteOpenEvent);
        OpenNews = new ExecuteCommand(ExecuteOpenNews, CanExecuteOpenNews);
        OpenLesson = new ExecuteCommand(ExecuteOpenLesson, CanExecuteOpenLesson);
    }
}
