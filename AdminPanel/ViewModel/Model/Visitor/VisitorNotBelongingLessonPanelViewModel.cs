using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorNotBelongingLessonPanelViewModel : General.ViewModel.ViewModel
{
    private readonly ISharedService _sharedService;
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly IMessageService _messageService;
    private readonly IControlViewService _controlViewService;
    private readonly LessonEntity _lessonEntity;

    public ICollection<VisitorEntity> VisitorEntities { get; private set => Set(ref field, value); }

    #region CommandAddVisitor

    internal readonly ICommand AddVisitor;

    private void ExecuteAddVisitor(object? obj)
    {
        var visitor = obj as VisitorEntity;
        _lessonEntity.AddVisitor(visitor);

        _repositoryL.Update(_lessonEntity);
        _sharedService.SetData(_lessonEntity);
        _messageService.Message("Посититель успешно добавлен", TypeMessage.Info);
        _controlViewService.Exit();
    }

    private bool CanExecuteAddVisitor(object? obj) => _lessonEntity.IsAddVisitor() && obj is VisitorEntity;

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public VisitorNotBelongingLessonPanelViewModel(
        ISharedService sharedService,
        IRepository<VisitorEntity> repositoryV,
        IRepository<LessonEntity> repositoryL,
        IMessageService messageService,
        IControlViewService controlViewService)
    {
        _lessonEntity = sharedService.GetData<LessonEntity>();
        VisitorEntities = repositoryV
            .Get()
            .Where(v => !_lessonEntity.Visitors.Select(v => v.Id).Contains(v.Id))
            .ToArray();

        _sharedService = sharedService;
        _repositoryL = repositoryL;
        _messageService = messageService;
        _controlViewService = controlViewService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        AddVisitor = new ExecuteCommand(ExecuteAddVisitor, CanExecuteAddVisitor);
    }
}