using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;

namespace Admin.ViewModel.Visitor;

public class VisitorDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IMessageService _messageService;
    private readonly IAuthService _authService;
    private readonly IRepository<VisitorEntity> _repositoryV;
    private readonly IImageFileService _imageFileService;
    private readonly IControlViewService _controlViewService;
    private readonly VisitorEntity _visitorEntity;

    #region Property

    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday(10)] public string? DateBirth { get; set => Set(ref field, value); }
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }
    [NullImage] public string? Image
    {
        get;
        set
        {
            _imageFileService.DeleteImageFromDisk(field);
            Set(ref field, value);
        }
    }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;

    private void ExecuteUpdate(object? obj)
    {
        _visitorEntity
            .UpdateName(new NameValidObject(Name))
            .UpdateSurname(new SurnameValidObject(Surname))
            .UpdatePatronymic(new PatronymicValidObject(Patronymic))
            .UpdateDateBirth(new DateBirthVisitorValidObject(DateOnly.Parse(DateBirth)))
            .UpdateImage(new ImageValidObject(_imageFileService.SaveImageToDick(Image)))
            .UpdateNumberPhone(new NumberPhoneValidObject(NumberPhone));

        _authService.UpdateAuth(_visitorEntity.AuthEntity);
        _repositoryV.Update(_visitorEntity);
        _authService.MessageAuth();

        _controlViewService.Exit();
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
        IAuthService authService,
        IRepository<VisitorEntity> repositoryV,
        IImageFileService imageFileService,
        IMessageService messageService,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        _authService = authService;
        _repositoryV = repositoryV;
        _imageFileService = imageFileService;
        _messageService = messageService;
        _controlViewService = controlViewService;

        _visitorEntity = sharedService.GetData<VisitorEntity>();

        Name = _visitorEntity.Name;
        Surname = _visitorEntity.Surname;
        Patronymic = _visitorEntity.Patronymic;
        NumberPhone = _visitorEntity.NumberPhone;
        DateBirth = _visitorEntity.DateBirth;
        Image = imageFileService.GetFullPath(_visitorEntity.Image);

        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
    }

    public IEnumerable<string> GetDateAttendance() => _visitorEntity.DateAttendances.Select(d => d.ToString("dd/MM"));
    public IEnumerable<string[]> GetAttendace() => _visitorEntity.GetLessonWithAttendance();
}