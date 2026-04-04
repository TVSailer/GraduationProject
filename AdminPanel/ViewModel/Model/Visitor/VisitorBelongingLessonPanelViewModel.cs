using System.Windows.Input;
using Admin.View.Moduls.Visitor;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorBelongingLessonPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly ISharedService _sharedService;
    private readonly IControlViewService _controlViewService;
    private readonly IMessageService _messageService;

    private LessonEntity _lessonEntity;

    public ICollection<VisitorEntity> VisitorEntities { get; private set => Set(ref field, value); }

    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _lessonEntity.RemoveVisitor((VisitorEntity)obj);
        _repositoryL.Update(_lessonEntity);

        VisitorEntities = _lessonEntity.Visitors;
        OnPropertyChange(nameof(VisitorEntities));
    }

    private bool CanExecuteDelete(object? obj)
    {
        if (_messageService.Message("Вы уверенны, что хотите удалть?", TypeMessage.YesCancel) is TypeCommandMessage.Cancel) return false;
        return obj is VisitorEntity;
    }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj)
    {
        _controlViewService.Exit();
    }

    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandLoadVisitorNotBelogingLessonPanelView

    internal readonly ICommand LoadVisitorNotBelogingLessonPanelView;

    private void ExecuteLoadVisitorNotBelogingLessonPanelView(object? obj)
    {
        _sharedService.SetData(_lessonEntity);
        _controlViewService.LoadView<VisitorNotBelongingLessonPanelViewModel>();
        VisitorEntities = _lessonEntity.Visitors;
    }

    private bool CanExecuteLoadVisitorNotBelogingLessonPanelView(object? obj) => _lessonEntity.IsAddVisitor();

    #endregion
    #region CommandLoadVisitorAddingPanelView

    internal readonly ICommand LoadVisitorAddingPanelView;

    private void ExecuteLoadVisitorAddingPanelView(object? obj)
    {
        _sharedService.SetData(_lessonEntity);
        _controlViewService.LoadView<VisitorAddingPanelViewModel>();
        VisitorEntities = _lessonEntity.Visitors;
    }

    private bool CanExecuteLoadVisitorAddingPanelView(object? obj) => _lessonEntity.IsAddVisitor();

    #endregion

    public VisitorBelongingLessonPanelViewModel(
        IRepository<LessonEntity> repositoryL,
        ISharedService sharedService,
        IControlViewService controlViewService,
        IMessageService messageService
    )
    {
        _lessonEntity = sharedService.GetData<LessonEntity>();
        VisitorEntities = _lessonEntity.Visitors;

        _repositoryL = repositoryL;
        _sharedService = sharedService;
        _controlViewService = controlViewService;
        _messageService = messageService;

        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        LoadVisitorNotBelogingLessonPanelView = new ExecuteCommand(ExecuteLoadVisitorNotBelogingLessonPanelView, CanExecuteLoadVisitorNotBelogingLessonPanelView);
        LoadVisitorAddingPanelView = new ExecuteCommand(ExecuteLoadVisitorAddingPanelView, CanExecuteLoadVisitorAddingPanelView);
    }
}