using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Ninject.Infrastructure.Language;

namespace Teacher.ViewModel.News;

public class NewsManagerPanelViewModel : General.ViewModel.ViewModel
{
    private const int PAGE_SIZE = 5;
    private int _pageNumber;

    private readonly IControlViewService _controlViewService;
    private readonly IRepository<NewsEntity> _repositoryN;

    public IEnumerable<NewsEntity> News { get; set => Set(ref field, value); }

    #region CommandNext

    internal readonly ICommand Next;

    private void ExecuteNext(object? obj)
    {
        _pageNumber += 1;
        News = GetNewsPageAsync(_pageNumber);
    }

    private bool CanExecuteNext(object? obj)
    {
        var i = (int)Math.Ceiling((double)_repositoryN.Get().Count() / PAGE_SIZE);
        return i - 1 > _pageNumber;
    }

    #endregion
    #region CommandPrevious

    internal readonly ICommand Previous;

    private void ExecutePrevious(object? obj)
    {
        _pageNumber -= 1;
        News = GetNewsPageAsync(_pageNumber);
    }

    private bool CanExecutePrevious(object? obj) => _pageNumber >= 1;

    #endregion
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

        News = GetNewsPageAsync(_pageNumber);

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        Next = new ExecuteCommand(ExecuteNext, CanExecuteNext);
        Previous = new ExecuteCommand(ExecutePrevious, CanExecutePrevious);
    }

    public IEnumerable<NewsEntity> GetNewsPageAsync(int pageNumber)
        => _repositoryN.Get()
            .OrderByDescending(n => n.Date)
            .Skip(pageNumber * PAGE_SIZE)
            .Take(PAGE_SIZE)
            .ToEnumerable();
}