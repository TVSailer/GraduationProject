using Domain.Command;
using Domain.Entitys;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MementoService.BaseMementoService;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;
using Domain.Repository;
using Teacher.ViewModel.DateAttendance;
using Teacher.ViewModel.Visitor;

namespace Teacher.ViewModel.Lesson;

public class LessonManagerPanelViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly TeacherEntity _teacherEntity;

    public IEnumerable<LessonEntity> LessonEntities => _repositoryL
        .Get()
        .AsEnumerable()
        .Where(l => _teacherEntity.Lessons
            .Select(lt => lt.Id)
            .Contains(l.Id));

    #region CommandControlVisitors

    internal readonly ICommand ControlVisitors;

    private void ExecuteControlVisitors(object? obj)
    {
        _sharedService.SetData(obj);
        _controlViewService.LoadView<VisitorBelongingLessonPanelViewModel>();
    }

    private bool CanExecuteControlVisitors(object? obj) => obj is LessonEntity ? true : throw new Exception();

    #endregion
    #region CommandControlDateAttendance

    internal readonly ICommand ControlDateAttendance;

    private void ExecuteControlDateAttendance(object? obj)
    {
        _sharedService.SetData(obj);
        _controlViewService.LoadView<DateAttendanceManagerPanelViewModel>();
    }

    private bool CanExecuteControlDateAttendance(object? obj) => obj is LessonEntity ? true : throw new Exception();

    #endregion
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
        IRepository<LessonEntity> repositoryL,
        IMementoService<TeacherEntity> mementoService)
    {
        _teacherEntity = mementoService.Get().Value;
        _controlViewService = controlViewService;
        _sharedService = sharedService;
        _repositoryL = repositoryL;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        OpenLesson = new ExecuteCommand(ExecuteOpenLesson, CanExecuteOpenLesson);
        ControlVisitors = new ExecuteCommand(ExecuteControlVisitors, CanExecuteControlVisitors);
        ControlDateAttendance = new ExecuteCommand(ExecuteControlDateAttendance, CanExecuteControlDateAttendance);
    }
}