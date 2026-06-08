using Domain.Command;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using System.Windows.Input;

namespace Admin.ViewModel.Event;

public class EventDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IImageService _imageService;
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
    public IEnumerable<string> Images { get; set => Set(ref field, value); }
    #endregion
    #region CommandToggleImage

    internal readonly ICommand ToggleImage;

    private void ExecuteToggleImage(object? obj) => _imageService.ToggleImage((string)obj!);
    private bool CanExecuteToggleImage(object? obj) => obj is string ? true : throw new ArgumentException();

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj)
    {
        _controlViewService.Exit();
        _imageService.Dispose();
    }

    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandAddImages

    internal readonly ICommand AddImages;

    private void ExecuteAddImages(object? obj) => _imageService.AddImage();
    private bool CanExecuteAddImages(object? obj) => true;

    #endregion
    #region CommandRemoveImages

    internal readonly ICommand RemoveImages;

    private async void ExecuteRemoveImages(object? obj)
    {
        _imageService.RemoveIsValueImages();
    }

    private bool CanExecuteRemoveImages(object? obj) => _messageService.Message("Вы действительно хотите удалить изображение?", TypeMessage.YesCancel) == TypeCommandMessage.Yes;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;

    private async void ExecuteUpdate(object? obj)
    {
        _eventEntity
            .UpdateTitle(new TitleValidObject(Title))
            .UpdateDescription(new DescriptionValidObject(Description))
            .UpdateLocation(new LocationValidObject(Location))
            .UpdateHttpLink(new HttpLinkValidObject(RegisLink))
            .UpdateCategory(Category)
            .UpdateSchedule(Schedule);

        var images = await _imageService.UpdateImagesFromCloudDisk();

        var image = await _imageService.UpdateImageFromCloudDisk();

        _eventEntity
            .UpdateTitleImage(new ImageValidObject(image.CloudPath))
            .UpdateImages(images);

        await _repositoryE.UpdateAsync(_eventEntity);

        _messageService.Message("Данные успешно обновились", TypeMessage.Info);
    }

    private bool CanExecuteUpdate(object? obj) 
        => _messageService.Message("Данные безвозратно изменяться!", TypeMessage.YesCancel) == TypeCommandMessage.Yes && ValidObject();

    #endregion
    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _imageService.ClearImage();
        _imageService.ClearImages();
        _repositoryE.Delete(_eventEntity.Id);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj)
        => _messageService.Message("Вы действительно хотите удалить?", TypeMessage.YesCancel) is TypeCommandMessage.Yes;

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
        _imageService = imageService;
        _messageService = messageService;
        _controlViewService = controlViewService;
        CategoryEntities = repositoryC.Get().ToArray();

        _eventEntity = sharedService.GetData<EventEntity>();

        Title = _eventEntity.Title;
        RegisLink = _eventEntity.RegistrationLink;
        Category = _eventEntity.Category;
        Location = _eventEntity.Location;
        Description = _eventEntity.Description;
        TimeStart = _eventEntity.Schedule.Start;
        TimeEnd = _eventEntity.Schedule.End;
        Date = _eventEntity.Schedule.Date;
        Organizer = _eventEntity.Organizer;

        _imageService.BindingImages(this, nameof(Images), _eventEntity.Images.Select(i => i.Url));
        _imageService.BindingImage(this, nameof(TitleImg), _eventEntity.UrlTitleImag);

        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        RemoveImages = new ExecuteCommand(ExecuteRemoveImages, CanExecuteRemoveImages);
        AddImages = new ExecuteCommand(ExecuteAddImages, CanExecuteAddImages);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
        ToggleImage = new ExecuteCommand(ExecuteToggleImage, CanExecuteToggleImage);
    }
}