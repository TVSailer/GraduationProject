using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuthService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Valid.AttributeValid;
using System.Windows.Input;
using Domain.Enum;
using Domain.Service.SharedService.BaseSharedService;

namespace Admin.ViewModel.Model.Teacher;

public class TeacherDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IRepository<TeacherEntity> _repositoryT;
    private readonly IRepository<AuthEntity> _repositoryA;
    private readonly IMessageService _messageService;
    private readonly IAuthService _authService;
    private readonly TeacherEntity _teacher;

    #region Property

    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday] public string? DateBirth { get; set => Set(ref field, value); }
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }
    [Image] public string? Image { get; set => Set(ref field, value); }

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
        _teacher.Name = Name;
        _teacher.Surname = Surname;
        _teacher.Patronymic = Patronymic;
        _teacher.DateBirth = DateBirth;
        _teacher.Image = Image;
        _teacher.NumberPhone = NumberPhone;

        _teacher.AuthEntity.Login = _authService.GenerateAuthLogin(Surname);
        _teacher.AuthEntity.Password = _authService
            .GenerateAuthPassword(
                _repositoryA
                    .Get()
                    .Select(a => a.Password)
                    .ToArray(), out var result);

        _repositoryA.Update(_teacher.AuthEntity);
        _repositoryT.Update(_teacher);

        _messageService.Message(
            $"Новый логин: {_teacher.AuthEntity.Login}" +
            $"\n" +
            $"Новый пароль: {result}", TypeMessage.Info);

        _controlViewService.Exit();
    }

    private bool CanExecuteUpdate(object? obj) => ValidObject();

    #endregion
    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _repositoryT.Delete(_teacher.Id);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj)
    {
        if (_teacher.Lessons is not { Count: 0 })
        {
            _messageService.Message("Для удаления преподователь не должен вести ни каких урков!", TypeMessage.Error);
            return false;
        }
        return _messageService.Message("Вы дейсвительно хотите удалть?", TypeMessage.YesCancel) is TypeCommandMessage.Yes;
    }

    #endregion

    public TeacherDetailsPanelViewModel(
        IControlViewService controlViewService,
        ISharedService sharedService,
        IRepository<TeacherEntity> repositoryT,
        IRepository<AuthEntity> repositoryA,
        IMessageService messageService,
        IAuthService authService)
    {
        _teacher = (TeacherEntity)sharedService.GetData();

        Name = _teacher.Name;
        Surname = _teacher.Surname;
        Patronymic = _teacher.Patronymic;
        NumberPhone = _teacher.NumberPhone;
        DateBirth = _teacher.DateBirth;
        Image = _teacher.Image;

        _controlViewService = controlViewService;
        _repositoryT = repositoryT;
        _repositoryA = repositoryA;
        _messageService = messageService;
        _authService = authService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
    }

    public IEnumerable<object[]> GetDataGridLesson() 
        => _teacher.Lessons.Select(lesson => (object[])[lesson.Title, lesson.Location]);
}
