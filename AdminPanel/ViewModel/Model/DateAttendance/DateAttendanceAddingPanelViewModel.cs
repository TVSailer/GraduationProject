using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using ExtensionFunc;

namespace Admin.ViewModel.Model.DateAttendance;

public class DateAttendanceAddingPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<DateAttendanceEntity> _repositoryD;
    private readonly IControlViewService _controlViewService;
    private readonly IMessageService _messageService;
    private readonly LessonEntity _lessonEntity;

    public readonly Dictionary<VisitorEntity, bool> VisitorEntities = [];

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.CloseDialog();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandAdd

    internal readonly ICommand Add;

    private void ExecuteAdd(object? obj)
    {
        var date = new DateAttendanceEntity(_lessonEntity);
        date.AddRangeVisitor(VisitorEntities
            .Where(c => c.Value)
            .Select(v => v.Key)
            .ToArray());

        _repositoryD.Add(date);
        _controlViewService.CloseDialog();
    }

    private bool CanExecuteAdd(object? obj)
    {
        if (_lessonEntity.IsAddDateAttendance()) return true;
        _messageService.Message("По расписанию сейчас нет урока", TypeMessage.Error);
        return false;
    }

    #endregion
    #region CommandSelectItem

    internal readonly ICommand SelectItem;

    private void ExecuteSelectItem(object? obj)
    {
        var visitor = obj as VisitorEntity;
        VisitorEntities[visitor] = !VisitorEntities[visitor];
    }

    private bool CanExecuteSelectItem(object? obj)
    {
        return obj is not VisitorEntity && VisitorEntities.ContainsKey((VisitorEntity)obj) ? throw new Exception() : true;
    }

    #endregion

    public DateAttendanceAddingPanelViewModel(
        ISharedService sharedService,
        IRepository<VisitorEntity> repositoryV,
        IRepository<DateAttendanceEntity> repositoryD,
        IControlViewService controlViewService,
        IMessageService messageService
        )
    {
        repositoryV
            .Get()
            .AsEnumerable()
            .ForEach(v => VisitorEntities.Add(v, false));

        _lessonEntity = sharedService.GetData<LessonEntity>();
        _repositoryD = repositoryD;
        _controlViewService = controlViewService;
        _messageService = messageService;

        SelectItem = new ExecuteCommand(ExecuteSelectItem, CanExecuteSelectItem);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Add = new ExecuteCommand(ExecuteAdd, CanExecuteAdd);
    }
}