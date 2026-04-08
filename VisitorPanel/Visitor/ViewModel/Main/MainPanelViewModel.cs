using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MementoService.BaseMementoService;
using System.Windows.Input;
using Visitor.ViewModel.Enter;
using Visitor.ViewModel.Event;
using Visitor.ViewModel.Lesson;
using Visitor.ViewModel.News;
using Visitor.ViewModel.Visitor;

namespace Visitor.ViewModel.Main;

public class MainPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IAuthFileService _authFileService;
    private readonly IRepository<VisitorEntity> _repositoryV;
    private readonly IMementoService<VisitorEntity> _mementoService;

    #region CommandOpenEnter

    internal readonly ICommand OpenEnter;

    private void ExecuteOpenEnter(object? obj)
    {
        if (_mementoService.Get().HasValue)
        {
            _controlViewService.LoadView<VisitorProfelPanelViewModel>();
            return;
        }

        if (_authFileService.Exists())
        {
            var auth = _authFileService.ReadAuth();
            var visitor = _repositoryV
                .Get()
                .ToArray()
                .SingleOrDefault(v => v.AuthEntity.Equals(auth.login, auth.password));

            if (visitor is not null)
            {
                _mementoService.Set(visitor);
                _controlViewService.LoadView<VisitorProfelPanelViewModel>();
                return;
            }
        }

        _controlViewService.ShowDialog<EnterPanelViewModel>();
    }

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
        IAuthFileService authFile,
        IRepository<VisitorEntity> repositoryV,
        IMementoService<VisitorEntity> mementoService)
    {
        _controlViewService = controlViewService;
        _authFileService = authFile;
        _repositoryV = repositoryV;
        _mementoService = mementoService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        OpenEnter = new ExecuteCommand(ExecuteOpenEnter, CanExecuteOpenEnter);
        OpenEvent = new ExecuteCommand(ExecuteOpenEvent, CanExecuteOpenEvent);
        OpenNews = new ExecuteCommand(ExecuteOpenNews, CanExecuteOpenNews);
        OpenLesson = new ExecuteCommand(ExecuteOpenLesson, CanExecuteOpenLesson);
    }
}
