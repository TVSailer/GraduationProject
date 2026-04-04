using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;

namespace Admin.ViewModel.Model.DateAttendance;

public class DateAttendanceManagerPanelViewModel : General.ViewModel.ViewModel
{
    private readonly ISharedService _sharedService;
    private readonly IControlViewService _controlViewService;
    private readonly IMessageService _messageService;
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
        _controlViewService.ShowDialog<DateAttendanceAddingPanelViewModel>();
    }

    private bool CanExecuteAdd(object? obj)
    {
        if (_lessonEntity.IsAddDateAttendance()) return true;
        _messageService.Message("По расписанию сегодня нет урока или вы уже отмечали прогулы", TypeMessage.Error);
        return false;
    }

    #endregion

    public DateAttendanceManagerPanelViewModel(
        ISharedService sharedService,
        IControlViewService controlViewService,
        IMessageService messageService
    )
    {
        _lessonEntity = sharedService.GetData<LessonEntity>();
        _sharedService = sharedService;
        _controlViewService = controlViewService;
        _messageService = messageService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Add = new ExecuteCommand(ExecuteAdd, CanExecuteAdd);
    }

    public IEnumerable<string[]> GetVisitorWithAttendance()
        => _lessonEntity.GetVisitorWithAttendance();

    public IEnumerable<string> GetDateAttendance()
        => _lessonEntity.GetDateAttendance("dd/MM");
}