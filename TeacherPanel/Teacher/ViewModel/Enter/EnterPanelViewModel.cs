using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MementoService.BaseMementoService;
using Domain.Service.MessageService.BaseMessageService;
using Teacher.ViewModel.Teacher;

namespace Teacher.ViewModel.Enter;

public class EnterPanelViewModel
{
    private readonly IMessageService _messageService;
    private readonly IAuthFileService _fileService;
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
        var visitor = _repositoryT
            .Get()
            .ToArray()
            .Single(v => v.AuthEntity.Equals(Login, Password));

        _mementoService.Set(visitor);
        _fileService.WriteAuth(visitor.AuthEntity);

        _controlViewService.CloseDialog();
        _controlViewService.LoadView<TeacherProfelPanelViewModel>();
    }

    private bool CanExecuteEnter(object? obj)
    {
        var auths = _repositoryT
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
        IMementoService<TeacherEntity> mementoService,
        IRepository<TeacherEntity> repositoryT,
        IControlViewService controlViewService
        )
    {
        _messageService = messageService;
        _fileService = file;
        _mementoService = mementoService;
        _repositoryT = repositoryT;
        _controlViewService = controlViewService;

        Enter = new ExecuteCommand(ExecuteEnter, CanExecuteEnter);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}

