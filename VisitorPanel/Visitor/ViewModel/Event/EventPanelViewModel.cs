using System.Windows.Input;
using Domain.Command;
using Domain.Service.ControlViewService.BaseControlView;

namespace Visitor.ViewModel.Event;

public class EventPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public EventPanelViewModel(
        IControlViewService controlViewService
        )
    {
        _controlViewService = controlViewService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}