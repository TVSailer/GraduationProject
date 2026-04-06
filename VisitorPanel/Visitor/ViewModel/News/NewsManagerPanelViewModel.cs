using System.Windows.Input;
using Domain.Command;
using Domain.Service.ControlViewService.BaseControlView;

namespace Visitor.ViewModel.News;

public class NewsManagerPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;

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
    public NewsManagerPanelViewModel(
        IControlViewService controlViewService
    )
    {
        _controlViewService = controlViewService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
    }
}