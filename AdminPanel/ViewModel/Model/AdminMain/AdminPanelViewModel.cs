using Domain.Command;
using General.Service.ControlView.BaseControlView;
using System.Windows.Input;
using Admin.ViewModel.Model.Event;

namespace Admin.ViewModel.Model.AdminMain;

public class AdminPanelViewModel
{
    private readonly IServiceControlView _serviceControlView;

    #region CommandLoadEventManagerPanelView

    internal readonly ICommand LoadEventManagerPanelView;

    private void ExecuteLoadEventManagerPanelView(object? obj) => _serviceControlView.LoadView<EventManagerPanelViewModel>();
    private bool CanExecuteLoadEventManagerPanelView(object? obj) => true;

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _serviceControlView.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public AdminPanelViewModel(IServiceControlView serviceControlView)
    {
        _serviceControlView = serviceControlView;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        LoadEventManagerPanelView = new ExecuteCommand(ExecuteLoadEventManagerPanelView, CanExecuteLoadEventManagerPanelView);
    }
}