using CSharpFunctionalExtensions;
using Domain.Command;
using Domain.Entitys;
using Domain.Entitys.ImagesEntity;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Lesson;

public class LessonDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;
    private readonly IMessageService _messageService;
    private readonly IImageService _imageService;
    private readonly LessonEntity _lessonEntity;

    public readonly CategoryEntity[] CategoryEntities;
    public readonly TeacherEntity[] TeacherEntities;

    #region Property

    [Title] public string? Title { get; set => Set(ref field, value); }
    [Description] public string? Description { get; set => Set(ref field, value); }
    [Location] public string? Location { get; set => Set(ref field, value); }
    [MaxParticipants] public int MaxParticipants { get; set => Set(ref field, value); } = 1;
    [RequiredCustom] public CategoryEntity? Category { get; set => Set(ref field, value); }
    [RequiredCustom] public TeacherEntity? Teacher { get; set => Set(ref field, value); }
    public IEnumerable<string?> Images { get; set => Set(ref field, value); }
    private Maybe<ICollection<LessonScheduleEntity>> _schedule;
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
    #region CommandUpdate

    internal readonly ICommand Update;


    private void ExecuteUpdate(object? obj)
    {
        _lessonEntity.Title = Title;
        _lessonEntity.Description = Description;
        _lessonEntity.Location = Location;
        _lessonEntity.MaxParticipants = MaxParticipants;
        _lessonEntity.Category = Category;
        _lessonEntity.Teacher = Teacher;
        _lessonEntity.Schedule = _schedule.Value;
        _lessonEntity.Images = Images.Select(i => new ImageLessonEntity() { Url = i }).ToList();

        _repositoryL.Update(_lessonEntity);
        _messageService.Message("Данные успешно обновились", TypeMessage.Info);
    }

    private bool CanExecuteUpdate(object? obj)
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
        _sharedService.SetData(_schedule.Value);
        _controlViewService.ShowDialog<ScheduleViewModel>();
        _schedule = _sharedService.GetMaybeData<ICollection<LessonScheduleEntity>>();
    }

    private bool CanExecuteSchedule(object? obj) => true;

    #endregion

    public LessonDetailsPanelViewModel(
        IRepository<LessonEntity> repositoryL,
        IRepository<CategoryEntity> repositoryC,
        IRepository<TeacherEntity> repositoryT,
        IControlViewService controlViewService,
        ISharedService sharedService,
        IMessageService messageService,
        IImageService imageService)
    {
        _lessonEntity = sharedService.GetData<LessonEntity>();

        CategoryEntities = repositoryC.Get().ToArray();
        TeacherEntities = repositoryT.Get().ToArray();

        _repositoryL = repositoryL;
        _controlViewService = controlViewService;
        _sharedService = sharedService;
        _messageService = messageService;
        _imageService = imageService;

        _imageService.Binding(this, nameof(Images));

        Title = _lessonEntity.Title;
        Description = _lessonEntity.Description;
        Location = _lessonEntity.Location;
        MaxParticipants = _lessonEntity.MaxParticipants;
        Teacher = _lessonEntity.Teacher;
        Category = _lessonEntity.Category;
        Images = _lessonEntity.Images.Select(i => i.Url);

        _schedule = Maybe.From(() => _lessonEntity.Schedule);

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        AddImages = new ExecuteCommand(ExecuteAddImages, CanExecuteAddImages);
        RemoveImages = new ExecuteCommand(ExecuteRemoveImages, CanExecuteRemoveImages);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        Schedule = new ExecuteCommand(ExecuteSchedule, CanExecuteSchedule);
    }
}