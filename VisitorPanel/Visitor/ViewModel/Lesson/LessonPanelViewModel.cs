using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MementoService.BaseMementoService;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;
using Visitor.ViewModel.Review;

namespace Visitor.ViewModel.Lesson;

public class LessonPanelViewModel : General.ViewModel.ViewModel
{
    private readonly LessonEntity _lesson;
    private readonly IControlViewService _controlViewService;
    private readonly IMessageService _messageService;
    private readonly IMementoService<VisitorEntity> _mementoService;
    private readonly ISharedService _sharedService;

    #region Property

    public string Title => _lesson.Title;
    public TeacherEntity Teacher => _lesson.Teacher;
    public string Description => _lesson.Description;
    public IEnumerable<string>? Images { get; set => Set(ref field, value); }
    public IEnumerable<LessonScheduleEntity> Schedule => _lesson.Schedule;
    public IEnumerable<ReviewEntity> ReviewEntites => _lesson.Reviews;

    #endregion
    #region CommandAddComment

    internal readonly ICommand AddComment;

    private void ExecuteAddComment(object? obj)
    {
        var visitor = _mementoService.Get().Value;
        var comment = _lesson.Reviews.SingleOrDefault(r => r.Visitor.Id == visitor.Id);

        if (comment is null)
        {
            _sharedService.SetData(_lesson);
            _controlViewService.ShowDialog<ReviewAddingPanelViewModel>();
            return;
        }

        _sharedService.SetData(comment);
        _controlViewService.ShowDialog<ReviewDetailsPanelViewModel>();
    }

    private bool CanExecuteAddComment(object? obj)
    {
        if (!_mementoService.Get().HasNoValue) return true;
        _messageService.Message("Для добавления комментария, необходимо войти в свой профиль", TypeMessage.Info);
        return false;
    }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public LessonPanelViewModel(
        IControlViewService controlViewService,
        IMessageService messageService,
        IImageService imageService,
        IMementoService<VisitorEntity> mementoService,
        ISharedService sharedService
    )
    {
        _controlViewService = controlViewService;
        _messageService = messageService;
        _mementoService = mementoService;
        _sharedService = sharedService;

        _lesson = sharedService.GetData<LessonEntity>();

        imageService.BindingImages(this, nameof(Images), _lesson.GetImages());

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        AddComment = new ExecuteCommand(ExecuteAddComment, CanExecuteAddComment);
    }

    public string NameButtonComment()
        => _mementoService.Get().HasValue && _lesson.Reviews.Any(r => r.Visitor.Id == _mementoService.Get().Value.Id) ? "Редактировать комментарий" : "Добавить комментарий";
}