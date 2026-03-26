using Domain.Command;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Entitys.ImagesEntity;
using Domain.Repository;
using Domain.Valid.AttributeValid;
using System.Windows.Input;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService.BaseServiceImage;

namespace Admin.ViewModel.Model.Event;

public class EventAddingPanelViewModel : General.ViewModel.ViewModel
{
    internal readonly IImageService ImageService;

    private readonly IRepository<EventEntity> _repositoryE;
    private readonly IControlViewService _controlViewService;

    public readonly CategoryEntity[] CategoryEntities;

    #region Property

    [Title] public string? Title { get; set => Set(ref field, value); }
    [Image] public string? TitleImg { get; set => Set(ref field, value); }
    [Description] public string? Description { get; set => Set(ref field, value); }
    [Date] public string? Date { get; set => Set(ref field, value); } = DateTime.Now.ToShortDateString();
    #region TimeStart

    [Time] public string? TimeStart
    {
        get;
        set
        {
            Set(ref field, value);
            ValidProperty(Schedule, nameof(Schedule));
        }
    } = "10:00";

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
    } = "12:00";

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
    #region CommandSave

    internal readonly ICommand Save;

    private void ExecuteSave(object? obj)
    {
        _repositoryE.Add(
            new EventEntity(
                Title!, 
                TitleImg!, 
                Description!, 
                Location!, 
                RegisLink!, 
                Organizer!, 
                Schedule, 
                Category!, 
                ImageService.GetImages().Select(i => new ImageEventEntity { Url = i }).ToList())
            );

        _controlViewService.Exit();
    }

    private bool CanExecuteSave(object? obj) => ValidObject();

    #endregion

    public EventAddingPanelViewModel(IRepository<EventEntity> repositoryE, IRepository<CategoryEntity> repositoryC, IImageService imageService, IControlViewService controlViewService)
    {
        _repositoryE = repositoryE;
        ImageService = imageService;
        _controlViewService = controlViewService;
        CategoryEntities = repositoryC.Get().ToArray();

        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
        RemoveImages = new ExecuteCommand(ExecuteRemoveImages, CanExecuteRemoveImages);
        AddImages = new ExecuteCommand(ExecuteAddImages, CanExecuteAddImages);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}