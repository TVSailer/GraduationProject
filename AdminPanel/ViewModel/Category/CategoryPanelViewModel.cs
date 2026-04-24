using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using System.Windows.Input;
using Domain.Command;

namespace Admin.ViewModel.Category;

public class CategoryPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IMessageService _messageService;
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly IRepository<EventEntity> _repositoryE;
    private readonly IRepository<NewsEntity> _repositoryN;
    private readonly IRepository<CategoryEntity> _repositoryC;
    private readonly IControlViewService _controlViewService;

    public List<CategoryEntity> CategoryEntities { get; } = [];

    [Category] public string? Category { get;
        set => Set(ref field, value);
    }

    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        var category = obj as CategoryEntity;
        _repositoryC.Delete(category.Id);
        CategoryEntities.Remove(category);
        OnPropertyChange(nameof(CategoryEntities));
    }

    private bool CanExecuteDelete(object? obj)
    {
        if (obj is not CategoryEntity category) throw new Exception();
        if (!_repositoryL.Get().AsEnumerable().Select(l => l.Category.Id).Contains(category.Id) &&
            !_repositoryE.Get().AsEnumerable().Select(e => e.Category.Id).Contains(category.Id) &&
            !_repositoryN.Get().AsEnumerable().Select(n => n.Category.Id).Contains(category.Id)) return true;
        _messageService.Message("К данной категории привязанны другие объекты! \n" +
                                "Прежде чем удалить данную категорию, заменети " +
                                "ее на другую во всех объетах(Кружки, Новости, Мероприятия)!", TypeMessage.Info);
        return false;
    }

    #endregion
    #region CommandAddCategory

    internal readonly ICommand Add;

    private void ExecuteAddCategory(object? obj)
    {
        var category = new CategoryEntity(new CategoryValidObject(Category));
        CategoryEntities.Add(
            _repositoryC.Add(category));
        OnPropertyChange(nameof(CategoryEntities));
    }

    private bool CanExecuteAddCategory(object? obj)
    {
        if (!_repositoryC.Get().AsEnumerable().Select(c => c.Category).Contains(Category)) return ValidObject();
        _messageService.Message("Существует категория с таким же название!", TypeMessage.Error);
        return false;
    }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj)
        => _controlViewService.CloseDialog();

    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public CategoryPanelViewModel(
        IMessageService messageService,
        IRepository<LessonEntity> repositoryL,
        IRepository<EventEntity> repositoryE,
        IRepository<NewsEntity> repositoryN,
        IRepository<CategoryEntity> repositoryC,
        IControlViewService controlViewService
        )
    {
        _messageService = messageService;
        _repositoryL = repositoryL;
        _repositoryE = repositoryE;
        _repositoryN = repositoryN;
        _repositoryC = repositoryC;
        CategoryEntities = repositoryC.Get().ToList();
        _controlViewService = controlViewService;

        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
        Add = new ExecuteCommand(ExecuteAddCategory, CanExecuteAddCategory);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}