using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Extension;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;

namespace Teacher.ViewModel.Review;

public class ReviewDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IRepository<ReviewEntity> _repositoryR;
    private readonly ReviewEntity _reviewEntity;

    public readonly string[] Estimations = [
        Domain.Enum.Estimation.Badly.ToDescriptionString(),
        Domain.Enum.Estimation.Moderately.ToDescriptionString(),
        Domain.Enum.Estimation.Satisfactory.ToDescriptionString(),
        Domain.Enum.Estimation.Good.ToDescriptionString(),
        Domain.Enum.Estimation.Excellent.ToDescriptionString(),
    ];

    #region Property

    [Comment] public string? Comment
    {
        get;
        set => Set(ref field, value);
    }

    [RequiredCustom] public string Estimation
    {
        get;
        set => Set(ref field, value);
    }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.CloseDialog();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandUpdateComment

    internal readonly ICommand UpdateComment;

    private void ExecuteUpdateComment(object? obj)
    {
        _repositoryR.Update(_reviewEntity
            .UpdateRating(Estimation.FromDescriptionString<Estimation>())
            .UpdateComment(new CommentValidObject(Comment)));

        _controlViewService.CloseDialog();
    }

    private bool CanExecuteUpdateComment(object? obj) => ValidObject();

    #endregion

    public ReviewDetailsPanelViewModel(
        IControlViewService controlViewService,
        ISharedService sharedService,
        IRepository<ReviewEntity> repositoryR)
    {
        _controlViewService = controlViewService;
        _repositoryR = repositoryR;

        _reviewEntity = sharedService.GetData<ReviewEntity>();

        Comment = _reviewEntity.Comment;
        Estimation = _reviewEntity.Rating.EstimationDesctiption;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        UpdateComment = new ExecuteCommand(ExecuteUpdateComment, CanExecuteUpdateComment);
    }
}