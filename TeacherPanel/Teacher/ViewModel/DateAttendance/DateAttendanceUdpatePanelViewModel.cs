using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;

namespace Teacher.ViewModel.DateAttendance;

public class DateAttendanceUdpatePanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<DateAttendanceEntity> _repositoryD;
    private readonly IControlViewService _controlViewService;
    private readonly DateAttendanceEntity _dateAttendance;

    public readonly Dictionary<VisitorEntity, bool> VisitorEntities = [];

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.CloseDialog();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandAdd

    internal readonly ICommand Update;

    private void ExecuteUpdate(object? obj)
    {
        _dateAttendance.UpdateRangeVisitor(VisitorEntities
            .Where(c => c.Value)
            .Select(v => v.Key)
            .ToArray());

        _repositoryD.Update(_dateAttendance);
        _controlViewService.CloseDialog();
    }

    private bool CanExecuteUpdate(object? obj) => true;

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

    public DateAttendanceUdpatePanelViewModel(
        ISharedService sharedService,
        IRepository<DateAttendanceEntity> repositoryD,
        IControlViewService controlViewService
    )
    {
        var lessonEntity = sharedService.GetData<LessonEntity>();
        _repositoryD = repositoryD;
        _controlViewService = controlViewService;

        var dateAttendanceLesson = lessonEntity.AttendanceDates.Single(d => d.Date == DateTime.Now.ToString("dd.MM.yyyy"));
        _dateAttendance = _repositoryD.Get().AsEnumerable().Single(d => d.Id == dateAttendanceLesson.Id);
        lessonEntity.Visitors.ForEach(v => VisitorEntities.Add(v, _dateAttendance.Visitors.Contains(v)));

        SelectItem = new ExecuteCommand(ExecuteSelectItem, CanExecuteSelectItem);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
    }
}