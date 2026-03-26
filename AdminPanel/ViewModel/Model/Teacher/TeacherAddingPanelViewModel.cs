using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuthService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Valid.AttributeValid;

namespace Admin.ViewModel.Model.Teacher;

public class TeacherAddingPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IRepository<TeacherEntity> _repositoryT;
    private readonly IRepository<AuthEntity> _repositoryA;
    private readonly IMessageService _messageService;
    private readonly IAuthService _authService;
    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday] public string? DateBirth { get; set => Set(ref field, value); } = DateTime.Now.ToString("dd/MM/yyyy");
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }
    [Image] public string? Image { get; set => Set(ref field, value); }

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandSave

    internal readonly ICommand Save;

    private void ExecuteSave(object? obj)
    {
        var login = _authService.GenerateAuthLogin(Surname);
        var password = _authService
            .GenerateAuthPassword(
                _repositoryA
                    .Get()
                    .Select(a => a.Password)
                    .ToArray(), out var result);

        var auth = _repositoryA.Add(new AuthEntity(login, password));
        _repositoryT.Add(new TeacherEntity(Image, Name, Surname, Patronymic, DateBirth, NumberPhone, auth));
        _messageService.Message(
            $"Логин: {login}" +
            $"\n" +
            $"Пароль: {result}", TypeMessage.Info);

        _controlViewService.Exit();
    }

    private bool CanExecuteSave(object? obj) => ValidObject();

    #endregion

    public TeacherAddingPanelViewModel(
        IControlViewService controlViewService, 
        IRepository<TeacherEntity> repositoryT,
        IRepository<AuthEntity> repositoryA,
        IMessageService messageService,
        IAuthService authService)
    {
        _controlViewService = controlViewService;
        _repositoryT = repositoryT;
        _repositoryA = repositoryA;
        _messageService = messageService;
        _authService = authService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
    }
}