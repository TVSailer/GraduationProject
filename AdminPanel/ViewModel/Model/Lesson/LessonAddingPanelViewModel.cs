using Domain.Command;
using Domain.Entitys;
using Domain.Entitys.ImagesEntity;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using System.Windows.Input;
using Admin.ViewModel.Model.Lesson.Schedule;
using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Model.Lesson;

public class LessonAddingPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;
    private readonly IMessageService _messageService;
    private readonly IImageService _imageService;

    public readonly CategoryEntity[] CategoryEntities;
    public readonly TeacherEntity[] TeacherEntities;

    #region Property

    [Title] public string? Title { get; set => Set(ref field, value); }
    [Description] public string? Description { get; set => Set(ref field, value); }
    [Location] public string? Location { get; set => Set(ref field, value); }
    [MaxParticipants] public int MaxParticipants { get; set => Set(ref field, value); } = 1;
    [RequiredCustom] public CategoryEntity? Category { get; set => Set(ref field, value); }
    [RequiredCustom] public TeacherEntity? Teacher { get; set => Set(ref field, value); }
    public IEnumerable<string> Images { get; set => Set(ref field, value); }
    private Maybe<List<LessonScheduleEntity>> _schedule;
    #endregion

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandAddImages

    internal readonly ICommand AddImages;

    private void ExecuteAddImages(object? obj) => _imageService.OnAddImage();
    private bool CanExecuteAddImages(object? obj) => true;

    #endregion
    #region CommandRemoveImages

    internal readonly ICommand RemoveImages;

    private void ExecuteRemoveImages(object? obj) => _imageService.OnDeleteImage();
    private bool CanExecuteRemoveImages(object? obj) => true;

    #endregion
    #region CommandSave

    internal readonly ICommand Save;


    private void ExecuteSave(object? obj)
    {
        _repositoryL.Add(
            new LessonEntity(
                Title!,
                Description!,
                Location!,
                MaxParticipants,
                Category!,
                Teacher,
                _schedule.Value,
                Images)
        );

        _messageService.Message("Данные успешно добавились", TypeMessage.Info);
        _controlViewService.Exit();
    }

    private bool CanExecuteSave(object? obj)
    {
        if (_schedule.HasValue) return ValidObject();
        _messageService.Message("Добавте расписание", TypeMessage.Error);
        return false;
    }

    #endregion
    #region CommandSchedule

    internal readonly ICommand Schedule;

    private void ExecuteSchedule(object? obj)
    {
        _sharedService.SetData(_schedule.GetValueOrDefault(null));
        _controlViewService.ShowDialog<ScheduleViewModel>();
        _schedule = _sharedService.GetMaybeData<List<LessonScheduleEntity>>();
    }

    private bool CanExecuteSchedule(object? obj) => true;

    #endregion

    public LessonAddingPanelViewModel(
        IRepository<LessonEntity> repositoryL,
        IRepository<CategoryEntity> repositoryC,
        IRepository<TeacherEntity> repositoryT,
        IControlViewService controlViewService,
        ISharedService sharedService,
        IMessageService messageService,
        IImageService imageService)
    {
        CategoryEntities = repositoryC.Get().ToArray();
        TeacherEntities = repositoryT.Get().ToArray();

        _repositoryL = repositoryL;
        _controlViewService = controlViewService;
        _sharedService = sharedService;
        _messageService = messageService;
        _imageService = imageService;

        _imageService.Binding(this, nameof(Images));

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        AddImages = new ExecuteCommand(ExecuteAddImages, CanExecuteAddImages);
        RemoveImages = new ExecuteCommand(ExecuteRemoveImages, CanExecuteRemoveImages);
        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
        Schedule = new ExecuteCommand(ExecuteSchedule, CanExecuteSchedule);
    }
}