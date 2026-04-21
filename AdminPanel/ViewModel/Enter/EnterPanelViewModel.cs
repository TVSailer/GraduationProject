using Admin.ViewModel.AdminMain;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MessageService.BaseMessageService;
using System.Windows.Input;

namespace Admin.ViewModel.Enter;

public class EnterPanelViewModel
{
    private readonly IMessageService _messageService;
    private readonly IAuthFileService _fileService;
    private readonly IControlViewService _controlViewService;
    private readonly IRepository<AuthEntity> _repositoryA;

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
        var auths = _repositoryA
            .Get()
            .ToArray()
            .Single(a => a.Equals(Login, Password));

        _fileService.WriteAuth(auths);

        _controlViewService.CloseDialog();
        _controlViewService.LoadView<AdminPanelViewModel>();
    }

    private bool CanExecuteEnter(object? obj)
    {
        var auths = _repositoryA
            .Get()
            .ToArray()
            .SingleOrDefault(a => a.Equals(Login, Password));

        if (auths is not null) return true;

        _messageService.Message("Неверный пароль или логин", TypeMessage.Error);
        return true;
    }

    #endregion

    public EnterPanelViewModel(
        IMessageService messageService,
        IAuthFileService file,
        IRepository<AuthEntity> repositoryA,
        IControlViewService controlViewService
        )
    {
        _messageService = messageService;
        _fileService = file;
        _repositoryA = repositoryA;
        _controlViewService = controlViewService;

        Enter = new ExecuteCommand(ExecuteEnter, CanExecuteEnter);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}

