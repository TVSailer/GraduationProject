using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;

namespace Visitor.ViewModel.Event;

public class EventManagerPanelViewModel :  General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;
    private readonly IRepository<EventEntity> _repositoryE;

    public IEnumerable<EventEntity> Events => _repositoryE.Get().AsEnumerable();

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;

    private void ExecuteUpdate(object? obj) => _controlViewService.UpdateGui();
    private bool CanExecuteUpdate(object? obj) => true;

    #endregion
    #region CommandOpenEvent

    internal readonly ICommand OpenEvent;

    private void ExecuteOpenEvent(object? obj)
    {
        _sharedService.SetData(obj);
        _controlViewService.LoadView<EventPanelViewModel>();
    }

    private bool CanExecuteOpenEvent(object? obj) => obj is EventEntity ? true : throw new Exception();

    #endregion
    public EventManagerPanelViewModel(
        IControlViewService controlViewService,
        ISharedService sharedService,
        IRepository<EventEntity> repositoryE)
    {
        _controlViewService = controlViewService;
        _sharedService = sharedService;
        _repositoryE = repositoryE;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        OpenEvent = new ExecuteCommand(ExecuteOpenEvent, CanExecuteOpenEvent);
    }
}