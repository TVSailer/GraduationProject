using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuthService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MementoService.BaseMementoService;
using Domain.Service.MessageService.BaseMessageService;

namespace Visitor.ViewModel.Enter;

public class EnterPanelViewModel
{
    private readonly IMessageService _messageService;
    private readonly IAuthService _authService;
    private readonly IMementoService<VisitorEntity> _mementoService;
    private readonly IRepository<VisitorEntity> _repositoryV;
    private readonly IControlViewService _controlViewService;
    public string? Login { get; set; }
    public string? Password { get; set; }

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandEnter

    internal readonly ICommand Enter;

    private void ExecuteEnter(object? obj)
    {
        _mementoService.Set(
            _repositoryV.Get().Single(v => v.AuthEntity.Equals(Login, Password)));
    }

    private bool CanExecuteEnter(object? obj)
    {
        var auths = _repositoryV.Get().Select(v => v.AuthEntity);

        if (!_authService.Verify(auths.ToArray(), Login, Password)) 
            _messageService.Message("Неверный пароль или логин", TypeMessage.Error);

         return true;
    }

    #endregion

    public EnterPanelViewModel(
        IMessageService messageService,
        IAuthService authService,
        IMementoService<VisitorEntity> mementoService,
        IRepository<VisitorEntity> repositoryV,
        IControlViewService controlViewService
        )
    {
        _messageService = messageService;
        _authService = authService;
        _mementoService = mementoService;
        _repositoryV = repositoryV;
        _controlViewService = controlViewService;

        Enter = new ExecuteCommand(ExecuteEnter, CanExecuteEnter);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}

