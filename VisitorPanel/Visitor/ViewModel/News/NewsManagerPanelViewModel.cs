using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;

namespace Visitor.ViewModel.News;

public class NewsManagerPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IRepository<NewsEntity> _repositoryN;

    public IEnumerable<NewsEntity> News => _repositoryN.Get().AsEnumerable();

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
        IControlViewService controlViewService,
        IRepository<NewsEntity> repositoryN)
    {
        _controlViewService = controlViewService;
        _repositoryN = repositoryN;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
    }
}