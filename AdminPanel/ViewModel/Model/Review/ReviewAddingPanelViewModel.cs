using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Review;

public class ReviewDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<ReviewEntity> _repositoryR;
    private readonly IMessageService _messageService;
    private readonly IControlViewService _controlViewService;
    private readonly ReviewEntity _reviewEntity;

    public int Rating { get; set => Set(ref field, value); }
    public VisitorEntity? Visitor { get; set => Set(ref field, value); }
    public string? Comment { get; set => Set(ref field, value); }

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object obj) => true;

    #endregion
    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _repositoryR.Delete(_reviewEntity.Id);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj)
        => _messageService.Message("Выдействительно хотите удалить?", TypeMessage.YesCancel) is TypeCommandMessage.Yes;

    #endregion

    public ReviewDetailsPanelViewModel(
        IControlViewService controlViewService,
        IRepository<ReviewEntity> repositoryR,
        IMessageService messageService,
        ISharedService sharedService
    )
    {
        _reviewEntity = sharedService.GetData<ReviewEntity>();

        Rating = (int)_reviewEntity.Rating;
        Visitor = _reviewEntity.Visitor;
        Comment = _reviewEntity.Comment;

        _controlViewService = controlViewService;
        _repositoryR = repositoryR;
        _messageService = messageService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
    }
}