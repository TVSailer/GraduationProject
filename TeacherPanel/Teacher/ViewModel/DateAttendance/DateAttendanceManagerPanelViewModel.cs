using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Service.AttendanceService.BaseAttendanceService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;

namespace Teacher.ViewModel.DateAttendance;

public class DateAttendanceManagerPanelViewModel : General.ViewModel.ViewModel
{
    private const string NAME_BUTTON_ADD = "Добавить";
    private const string NAME_BUTTON_UPDATE = "Обновить";

    public string NameButton = NAME_BUTTON_ADD;

    private readonly ISharedService _sharedService;
    private readonly IControlViewService _controlViewService;
    private readonly IMessageService _messageService;
    private readonly IAttendanceService _attendanceService;
    private readonly LessonEntity _lessonEntity;

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandAdd

    internal readonly ICommand Add;

    private void ExecuteAdd(object? obj)
    {
        _sharedService.SetData(_lessonEntity);
        if (NameButton == NAME_BUTTON_UPDATE)
        {
            _controlViewService.ShowDialog<DateAttendanceUdpatePanelViewModel>();
            return;
        }

        NameButton = NAME_BUTTON_UPDATE;
        _controlViewService.ShowDialog<DateAttendanceAddingPanelViewModel>();
    }

    private bool CanExecuteAdd(object? obj)
    {
        if (NameButton == NAME_BUTTON_UPDATE) return true;

        if (_lessonEntity.IsAddDateAttendance()) return true;
        _messageService.Message("По расписанию сегодня нет урока", TypeMessage.Warning);
        return false;
    }

    #endregion

    public DateAttendanceManagerPanelViewModel(
        ISharedService sharedService,
        IControlViewService controlViewService,
        IMessageService messageService,
        IAttendanceService attendanceService
    )
    {
        _lessonEntity = sharedService.GetData<LessonEntity>();
        _sharedService = sharedService;
        _controlViewService = controlViewService;
        _messageService = messageService;
        _attendanceService = attendanceService;

        if (_lessonEntity.IsUpdateDateAttendance())
            NameButton = NAME_BUTTON_UPDATE;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Add = new ExecuteCommand(ExecuteAdd, CanExecuteAdd);
    }

    public IEnumerable<string[]> GetVisitorWithAttendance()
        => _attendanceService.GetVisitorWithAttendance(_lessonEntity);

    public IEnumerable<string> GetDateAttendance()
        => _lessonEntity.AttendanceDates.OrderBy(d => d.ToDateTime()).Select(d => d.ToString("dd/MM"));
}