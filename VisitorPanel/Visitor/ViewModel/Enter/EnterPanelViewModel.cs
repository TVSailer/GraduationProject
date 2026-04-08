using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MementoService.BaseMementoService;
using Domain.Service.MessageService.BaseMessageService;
using System.Windows.Input;
using Visitor.ViewModel.Visitor;

namespace Visitor.ViewModel.Enter;

public class EnterPanelViewModel
{
    private readonly IMessageService _messageService;
    private readonly IAuthFileService _fileService;
    private readonly IMementoService<VisitorEntity> _mementoService;
    private readonly IRepository<VisitorEntity> _repositoryV;
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
        var visitor = _repositoryV
            .Get()
            .ToArray()
            .Single(v => v.AuthEntity.Equals(Login, Password));

        _mementoService.Set(visitor);
        _fileService.WriteAuth(visitor.AuthEntity);

        _controlViewService.CloseDialog();
        _controlViewService.LoadView<VisitorProfelPanelViewModel>();
    }

    private bool CanExecuteEnter(object? obj)
    {
        var auths = _repositoryV
            .Get()
            .ToArray()
            .Select(v => v.AuthEntity)
            .SingleOrDefault(a => a.Equals(Login, Password));

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
        IMementoService<VisitorEntity> mementoService,
        IRepository<VisitorEntity> repositoryV,
        IControlViewService controlViewService
        )
    {
        _messageService = messageService;
        _fileService = file;
        _mementoService = mementoService;
        _repositoryV = repositoryV;
        _controlViewService = controlViewService;

        Enter = new ExecuteCommand(ExecuteEnter, CanExecuteEnter);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}

