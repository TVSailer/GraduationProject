using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MementoService.BaseMementoService;
using Domain.Service.MessageService.BaseMessageService;
using Teacher.ViewModel.Main;
using Teacher.ViewModel.Teacher;

namespace Teacher.ViewModel.Enter;

public class EnterPanelViewModel
{
    private readonly IMessageService _messageService;
    private readonly IAuthFileService _fileService;
    private readonly IAuthService _authService;
    private readonly IMementoService<TeacherEntity> _mementoService;
    private readonly IRepository<TeacherEntity> _repositoryT;
    private readonly IControlViewService _controlViewService;
    public string? Login { get; set; }
    public string? Password { get; set; }

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.CloseDialog();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandEnter

    internal readonly ICommand Enter;

    private void ExecuteEnter(object? obj)
    {
        var teacher = _repositoryT
            .Get()
            .ToArray()
            .Single(v => v.AuthEntity.Equals(Login, Password, UserRole.Teacher));

        _mementoService.Set(teacher);
        _fileService.WriteAuth(teacher.AuthEntity);

        _controlViewService.CloseDialog();
        _controlViewService.LoadView<MainPanelViewModel>();
    }

    private bool CanExecuteEnter(object? obj)
    {
        var auths = _repositoryT
            .Get()
            .ToArray()
            .Select(v => v.AuthEntity)
            .SingleOrDefault(a => a.Equals(Login, Password, UserRole.Teacher));

        if (auths is null)
        {
            _messageService.Message("Неверный пароль или логин", TypeMessage.Error);
            return false;
        }

        return true;
    }

    #endregion

    public EnterPanelViewModel(
        IMessageService messageService,
        IAuthFileService file,
        IAuthService authService,
        IMementoService<TeacherEntity> mementoService,
        IRepository<TeacherEntity> repositoryT,
        IControlViewService controlViewService
        )
    {
        _messageService = messageService;
        _fileService = file;
        _authService = authService;
        _mementoService = mementoService;
        _repositoryT = repositoryT;
        _controlViewService = controlViewService;

        Enter = new ExecuteCommand(ExecuteEnter, CanExecuteEnter);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}

