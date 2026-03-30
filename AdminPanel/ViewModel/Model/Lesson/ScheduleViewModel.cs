using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using System.Windows.Input;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using Domain.Extension;
using Day = Domain.Enum.Day;



namespace Admin.ViewModel.Model.Lesson;

public class ScheduleViewModel : General.ViewModel.ViewModel
{
    private readonly ISharedService _sharedService;
    private readonly IMessageService _messageService;
    private readonly IControlViewService _controlViewService;

    public IEnumerable<string> DayOfWeeks => Enum.GetValues(typeof(Day))
        .Cast<Day>()
        .Select(d => d.ToDescriptionString());

    public List<LessonScheduleEntity> Schedule { get; } = [];

    [Time] public string StartTime { get => field ?? "11:00"; set => Set(ref field, value); }
    [Time] public string EndTime { get => field ?? "12:00"; set => Set(ref field, value); }
    [RequiredCustom] public string DayOfWeek { get; set => Set(ref field, value); }

    #region CommandAddSchedule

    internal readonly ICommand AddSchedule;

    private void ExecuteAddSchedule(object? obj)
    {
        Schedule.Add(new LessonScheduleEntity(
            TimeOnly.Parse(StartTime), 
            TimeOnly.Parse(EndTime), 
            DayOfWeek.FromDescriptionString<Day>()));
        OnPropertyChange(nameof(Schedule));
    }

    private bool CanExecuteAddSchedule(object? obj)
    {
        if (!ValidObject()) return false;

        if (!TimeOnly.TryParse(StartTime, out var start) || !TimeOnly.TryParse(EndTime, out var end))
            throw new Exception();

        if (start <= end) return true;

        OnMassageErrorProvider("Время начало не может быть позже конца", nameof(StartTime));
        OnMassageErrorProvider("Время начало не может быть позже конца", nameof(EndTime));

        return false;
    }

    #endregion
    #region CommandDeleteSchedule

    internal readonly ICommand DeleteSchedule;

    private void ExecuteDeleteSchedule(object? obj)
    {
        Schedule.Remove((LessonScheduleEntity)obj);
        OnPropertyChange(nameof(Schedule));
    }

    private bool CanExecuteDeleteSchedule(object? obj) => obj is LessonScheduleEntity;

    #endregion
    #region CommandSave

    internal readonly ICommand Save;

    private void ExecuteSave(object? obj)
    {
        _sharedService.SetData(Schedule);
        _messageService.Message("Данные успешно обновились/добавились", TypeMessage.Info);
    }

    private bool CanExecuteSave(object? obj)
    {
        if (Schedule.Count == 0)
        {
            _messageService.Message("Заполните форму!", TypeMessage.Error);
            return false;
        }
        return true;
    }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj)
    {
        _controlViewService.CloseDialog();
        _sharedService.SetData(Schedule);
    }

    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public ScheduleViewModel(ISharedService sharedService, IMessageService messageService, IControlViewService controlViewService)
    {
        _sharedService = sharedService;
        _messageService = messageService;
        _controlViewService = controlViewService;

        Schedule.AddRange(_sharedService.GetMaybeData<ICollection<LessonScheduleEntity>>().GetValueOrDefault([]));

        AddSchedule = new ExecuteCommand(ExecuteAddSchedule, CanExecuteAddSchedule);
        DeleteSchedule = new ExecuteCommand(ExecuteDeleteSchedule, CanExecuteDeleteSchedule);
        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}