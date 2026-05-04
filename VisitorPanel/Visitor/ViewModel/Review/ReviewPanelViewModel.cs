using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Extension;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MementoService.BaseMementoService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;

namespace Visitor.ViewModel.Review;

public class ReviewAddingPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IRepository<ReviewEntity> _repositoryR;
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly IMementoService<VisitorEntity> _mementoService;
    private readonly ISharedService _sharedService;

    public readonly string[] Estimations = [
        Domain.Enum.Estimation.Badly.ToDescriptionString(),
        Domain.Enum.Estimation.Moderately.ToDescriptionString(),
        Domain.Enum.Estimation.Satisfactory.ToDescriptionString(),
        Domain.Enum.Estimation.Good.ToDescriptionString(),
        Domain.Enum.Estimation.Excellent.ToDescriptionString(),
    ];

    #region Property

    [Comment] public string? Comment { get;
        set => Set(ref field, value);
    }

    [RequiredCustom] public string Estimation { get;
        set => Set(ref field, value);
    }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.CloseDialog();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandAddComment

    internal readonly ICommand AddComment;

    private void ExecuteAddComment(object? obj)
    {
        var lesson = _sharedService.GetData<LessonEntity>();
        var visitor = _mementoService.Get().Value;
        var estimation = Estimation.FromDescriptionString<Estimation>();
        var comment = new CommentValidObject(Comment);

        var review = new ReviewEntity(estimation, comment, visitor, lesson);

        lesson.AddReview(review);

        _repositoryR.Add(review);
        _repositoryL.Update(lesson);

        _controlViewService.CloseDialog();
    }

    private bool CanExecuteAddComment(object? obj) => ValidObject();

    #endregion

    public ReviewAddingPanelViewModel(
        IControlViewService controlViewService,
        IRepository<ReviewEntity> repositoryR,
        IRepository<LessonEntity> repositoryL,
        IMementoService<VisitorEntity> mementoService,
        ISharedService sharedService)
    {
        _controlViewService = controlViewService;
        _repositoryR = repositoryR;
        _repositoryL = repositoryL;
        _mementoService = mementoService;
        _sharedService = sharedService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        AddComment = new ExecuteCommand(ExecuteAddComment, CanExecuteAddComment);
    }
}