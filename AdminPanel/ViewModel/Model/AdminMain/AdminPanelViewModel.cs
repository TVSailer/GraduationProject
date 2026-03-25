using Domain.Command;
using General.Service.ControlView.BaseControlView;
using System.Windows.Input;
using Admin.ViewModel.Model.Event;

namespace Admin.ViewModel.Model.AdminMain;

public class AdminPanelViewModel
{
    private readonly IControlViewService _controlViewService;

    #region CommandLoadEventManagerPanelView

    internal readonly ICommand LoadEventManagerPanelView;

    private void ExecuteLoadEventManagerPanelView(object? obj) => _controlViewService.LoadView<EventManagerPanelViewModel>();
    private bool CanExecuteLoadEventManagerPanelView(object? obj) => true;

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public AdminPanelViewModel(IControlViewService controlViewService)
    {
        _controlViewService = controlViewService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        LoadEventManagerPanelView = new ExecuteCommand(ExecuteLoadEventManagerPanelView, CanExecuteLoadEventManagerPanelView);
    }
}