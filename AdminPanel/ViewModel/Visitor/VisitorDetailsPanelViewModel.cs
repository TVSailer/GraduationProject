using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using General.Service.File;

namespace Admin.ViewModel.Visitor;

public class VisitorDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IMessageService _messageService;
    private readonly IAuthService _authService;
    private readonly IRepository<VisitorEntity> _repositoryV;
    private readonly IImageService _imageService;
    private readonly IControlViewService _controlViewService;
    private readonly VisitorEntity _visitorEntity;
    private PathImageValidObject _imagePath;

    #region Property

    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday(10)] public string? DateBirth { get; set => Set(ref field, value); }
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }
    [NullImage] public string? ImageLocal { get; set => Set(ref field, value); }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    #region CommandUpdateAuth

    internal readonly ICommand UpdateAuth;

    private void ExecuteUpdateAuth(object? obj)
    {
        _authService.UpdateAuth(_visitorEntity.AuthEntity);
        _repositoryV.Update(_visitorEntity);
        _authService.MessageAuth();
    }

    private bool CanExecuteUpdateAuth(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;

    private void ExecuteUpdate(object? obj)
    {
        var image = _imageService.UpdateImageFromCloudDisk(ImageLocal);

        _visitorEntity
            .UpdateImage(new ImageValidObject(image.Result.CloudPath))
            .UpdateName(new NameValidObject(Name))
            .UpdateSurname(new SurnameValidObject(Surname))
            .UpdatePatronymic(new PatronymicValidObject(Patronymic))
            .UpdateDateBirth(new DateBirthVisitorValidObject(DateOnly.Parse(DateBirth)))
            .UpdateNumberPhone(new NumberPhoneValidObject(NumberPhone));

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
        _authService.Delete(_visitorEntity.AuthEntity);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj)
        => _messageService.Message("Выдействительно хотите удалить?", TypeMessage.YesCancel) is TypeCommandMessage.Yes;

    #endregion

    public VisitorDetailsPanelViewModel(
        IAuthService authService,
        IRepository<VisitorEntity> repositoryV,
        IImageService imageService,
        IMessageService messageService,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        _authService = authService;
        _repositoryV = repositoryV;
        _imageService = imageService;
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
        UpdateAuth = new ExecuteCommand(ExecuteUpdateAuth, CanExecuteUpdateAuth);

        _ = imageService.BindingImage(this, nameof(ImageLocal), _visitorEntity.Image);
    }

    public IEnumerable<string> GetDateAttendance() => _visitorEntity.DateAttendances
        .Select(d => d.ToString("dd/MM"))
        .Distinct()
        ;
    public IEnumerable<string[]> GetAttendace() => _visitorEntity.GetLessonWithAttendance();
}