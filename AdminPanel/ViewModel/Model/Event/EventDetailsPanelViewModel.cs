using Domain.Command;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Entitys.ImagesEntity;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using System.Windows.Input;
using Domain.Service.MessageService.BaseMessageService;

namespace Admin.ViewModel.Model.Event;

public class EventDetailsPanelViewModel : General.ViewModel.ViewModel
{
    internal readonly IImageService ImageService;
    private readonly IMessageService _messageService;

    private readonly IRepository<EventEntity> _repositoryE;
    private readonly IControlViewService _controlViewService;
    private readonly EventEntity _eventEntity;

    public readonly CategoryEntity[] CategoryEntities;

    #region Property

    [Title] public string? Title { get; set => Set(ref field, value); }
    [Image] public string? TitleImg { get; set => Set(ref field, value); }
    [Description] public string? Description { get; set => Set(ref field, value); }
    [Date] public string? Date { get; set => Set(ref field, value); }
    #region TimeStart

    [Time] public string? TimeStart
    {
        get;
        set
        {
            Set(ref field, value);
            ValidProperty(Schedule, nameof(Schedule));
        }
    }

    #endregion
    #region TimeEnd

    [Time] public string? TimeEnd
    {
        get;
        set
        {
            Set(ref field, value);
            ValidProperty(Schedule, nameof(Schedule));
        }
    } 

    #endregion
    [Location] public string? Location { get; set => Set(ref field, value); }
    [Organizer] public string? Organizer { get; set => Set(ref field, value); }
    [RequiredCustom] public CategoryEntity? Category { get; set => Set(ref field, value); }
    [Url] public string? RegisLink { get; set => Set(ref field, value); }
    [ScheduleEntity] public EventEntitySchedule Schedule => new (TimeStart, TimeEnd, Date);

    #endregion

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandAddImages

    internal readonly ICommand AddImages;

    private void ExecuteAddImages(object? obj) => ImageService.OnAddImage();
    private bool CanExecuteAddImages(object? obj) => true;

    #endregion
    #region CommandRemoveImages

    internal readonly ICommand RemoveImages;

    private void ExecuteRemoveImages(object? obj) => ImageService.OnDeleteImage();
    private bool CanExecuteRemoveImages(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;

    private void ExecuteUpdate(object? obj)
    {
        _eventEntity.Title = Title;
        _eventEntity.UrlTitleImag = TitleImg;
        _eventEntity.Location = Location;
        _eventEntity.Description = Description;
        _eventEntity.Category = Category;
        _eventEntity.RegistrationLink = RegisLink;
        _eventEntity.Schedule = Schedule;
        _eventEntity.Images = ImageService.GetImages().Select(i => new ImageEventEntity { Url = i }).ToList();

        _repositoryE.Update(_eventEntity);
    }

    private bool CanExecuteUpdate(object? obj) => ValidObject();

    #endregion
    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _repositoryE.Delete(_eventEntity.Id);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj)
        => _messageService.Message("Выдействительно хотите удалить?", TypeMessage.YesCancel) is TypeCommandMessage.Yes;

    #endregion
    public EventDetailsPanelViewModel(
        IRepository<EventEntity> repositoryE, 
        IRepository<CategoryEntity> repositoryC, 
        IImageService imageService, 
        IMessageService messageService,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        _repositoryE = repositoryE;
        ImageService = imageService;
        _messageService = messageService;
        _controlViewService = controlViewService;
        CategoryEntities = repositoryC.Get().ToArray();
        _eventEntity = (EventEntity)sharedService.GetData();

        Title = _eventEntity.Title;
        RegisLink = _eventEntity.RegistrationLink;
        Category = _eventEntity.Category;
        TitleImg = _eventEntity.UrlTitleImag;
        Location = _eventEntity.Location;
        Description = _eventEntity.Description;
        TimeStart = _eventEntity.Schedule.Start;
        TimeEnd = _eventEntity.Schedule.End;
        Date = _eventEntity.Schedule.Date;
        Organizer = _eventEntity.Organizer;
        ImageService.TryAdd(_eventEntity.Images.Select(i => i.Url));


        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        RemoveImages = new ExecuteCommand(ExecuteRemoveImages, CanExecuteRemoveImages);
        AddImages = new ExecuteCommand(ExecuteAddImages, CanExecuteAddImages);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
    }
}