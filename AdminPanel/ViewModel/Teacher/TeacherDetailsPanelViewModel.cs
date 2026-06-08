using Domain.Command;
using Domain.Entitys;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.EntityService.TeacherService;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Service.TaskService.BaseTaskService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using General.Service.File;
using System.Windows.Input;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;

namespace Admin.ViewModel.Teacher;

public class TeacherDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private readonly ITeacherService _teacherService;
    private readonly IAuthService _authService;
    private readonly IRepository<TeacherEntity> _repositoryT;
    private readonly IMessageService _messageService;
    private readonly IControlViewService _controlViewService;
    private readonly IImageService _imageService;
    private readonly TeacherEntity _teacher;

    #region Property

    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday] public string? DateBirth { get; set => Set(ref field, value); }
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }
    [Image] public string? ImageLocal { get; set => Set(ref field, value); }
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
        _authService.UpdateAuth(_teacher.AuthEntity);
        _repositoryT.Update(_teacher);
        _authService.MessageAuth();
    }

    private bool CanExecuteUpdateAuth(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;
    private void ExecuteUpdate(object? obj)
    {
        var image = _imageService.UpdateImageFromCloudDisk();

        _teacher
            .UpdateName(new NameValidObject(Name))
            .UpdateSurname(new SurnameValidObject(Surname))
            .UpdatePatronymic(new PatronymicValidObject(Patronymic))
            .UpdateDateBirth(new DateBirthTeacherValidObject(DateOnly.Parse(DateBirth)))
            .UpdateImage(new ImageValidObject(image.Result.CloudPath))
            .UpdateNumberPhone(new NumberPhoneValidObject(NumberPhone));

        _repositoryT.Update(_teacher);

        _messageService.Message("Данные успешно обновились", TypeMessage.Info);
    }
    private bool CanExecuteUpdate(object? obj) => ValidObject();

    #endregion
    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _imageService.ClearImage();
        _teacherService.ExecuteDelete(_teacher);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj) 
        => _teacherService.CanExecuteDelete(_teacher);

    #endregion

    public TeacherDetailsPanelViewModel(
        ITeacherService teacherService,
        IAuthService authService,
        IRepository<TeacherEntity> repositoryT,
        IMessageService messageService,
        IControlViewService controlViewService,
        IImageService imageService,
        ISharedService sharedService)
    {
        _teacherService = teacherService;
        _authService = authService;
        _repositoryT = repositoryT;
        _messageService = messageService;
        _controlViewService = controlViewService;
        _imageService = imageService;

        _teacher = sharedService.GetData<TeacherEntity>();

        Name = _teacher.Name;
        Surname = _teacher.Surname;
        Patronymic = _teacher.Patronymic;
        NumberPhone = _teacher.NumberPhone;
        DateBirth = _teacher.DateBirth;

        imageService.BindingImage(this, nameof(ImageLocal), _teacher.Image);

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
        UpdateAuth = new ExecuteCommand(ExecuteUpdateAuth, CanExecuteUpdateAuth);
    }

    public IEnumerable<object[]> GetDataGridLesson() 
        => _teacher.Lessons.Select(lesson => (object[])[lesson.Title, lesson.Location]);
}
