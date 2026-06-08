using Domain.Command;
using Domain.Entitys;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.SharedService.BaseSharedService;
using System.Windows.Input;

namespace Teacher.ViewModel.Lesson;

public class LessonPanelViewModel : General.ViewModel.ViewModel
{
    private readonly LessonEntity _lesson;
    private readonly IControlViewService _controlViewService;
    private readonly IImageFileService _imageFileService;

    #region Property

    public string Title => _lesson.Title;
    public TeacherEntity Teacher => _lesson.Teacher;
    public string Description => _lesson.Description;
    public string Location => _lesson.Location;
    public CategoryEntity Category => _lesson.Category;
    public IEnumerable<string>? Images { get; set => Set(ref field, value); }
    public IEnumerable<LessonScheduleEntity> Schedule => _lesson.Schedule;
    public IEnumerable<ReviewEntity> ReviewEntites => _lesson.Reviews;

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion

    public LessonPanelViewModel(
        IControlViewService controlViewService,
        IImageService imageFileService,
        ISharedService sharedService)
    {
        _controlViewService = controlViewService;
        _lesson = sharedService.GetData<LessonEntity>();

        imageFileService.BindingImages(this, nameof(Images), _lesson.GetImages());

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}