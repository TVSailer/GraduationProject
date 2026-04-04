using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IMessageService _messageService;
    private readonly IRepository<VisitorEntity> _repositoryV;
    private readonly IControlViewService _controlViewService;
    private readonly VisitorEntity _visitorEntity;

    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday(10)] public string? DateBirth { get; set => Set(ref field, value); }
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }
    [NullImage] public string? Image;

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;

    private void ExecuteUpdate(object? obj)
    {
        _visitorEntity.Name = Name;
        _visitorEntity.Surname = Surname;
        _visitorEntity.Patronymic = Patronymic;
        _visitorEntity.NumberPhone = NumberPhone;
        _visitorEntity.DateBirth = DateBirth;

        _repositoryV.Update(_visitorEntity);

        _messageService.Message("Данные успешно обновились", TypeMessage.Info);
    }

    private bool CanExecuteUpdate(object? obj) => ValidObject();

    #endregion
    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _repositoryV.Delete(_visitorEntity.Id);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj)
        => _messageService.Message("Выдействительно хотите удалить?", TypeMessage.YesCancel) is TypeCommandMessage.Yes;

    #endregion

    public VisitorDetailsPanelViewModel(
        IRepository<VisitorEntity> repositoryV,
        IMessageService messageService,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        _repositoryV = repositoryV;
        _messageService = messageService;
        _controlViewService = controlViewService;

        _visitorEntity = sharedService.GetData<VisitorEntity>();

        Name = _visitorEntity.Name;
        Surname = _visitorEntity.Surname;
        Patronymic = _visitorEntity.Patronymic;
        NumberPhone = _visitorEntity.NumberPhone;
        DateBirth = _visitorEntity.DateBirth;

        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
    }

    public IEnumerable<string> GetDateAttendance() => _visitorEntity.DateAttendances.Select(d => d.ToString("dd/MM"));
    public IEnumerable<string[]> GetAttendace() => _visitorEntity.GetLessonWithAttendance();
}