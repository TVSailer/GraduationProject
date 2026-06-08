using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using System.Windows.Input;
using Domain.Enum;
using Domain.Service.MessageService.BaseMessageService;

namespace Admin.ViewModel.News;

public class NewsAddingPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IImageService _imageService;
    private readonly IMessageService _messageService;
    private readonly IRepository<NewsEntity> _repositoryE;
    private readonly IControlViewService _controlViewService;

    public readonly CategoryEntity[] CategoryEntities;

    #region Property

    [Title] public string? Title { get; set => Set(ref field, value); }
    [Description] public string? Description { get; set => Set(ref field, value); }
    [Date] public string? Date { get; set => Set(ref field, value); } = DateTime.Now.ToShortDateString();
    [Author] public string? Author { get; set => Set(ref field, value); }
    [RequiredCustom] public CategoryEntity? Category { get; set => Set(ref field, value); }
    public IEnumerable<string> Images { get; set => Set(ref field, value); }
    #endregion

    #region CommandToggleImage

    internal readonly ICommand ToggleImage;

    private void ExecuteToggleImage(object? obj) => _imageService.ToggleImage((string)obj!);
    private bool CanExecuteToggleImage(object? obj) => obj is string ? true : throw new ArgumentException();

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandAddImages

    internal readonly ICommand AddImages;

    private void ExecuteAddImages(object? obj) => _imageService.AddImage();
    private bool CanExecuteAddImages(object? obj) => true;

    #endregion
    #region CommandRemoveImages

    internal readonly ICommand RemoveImages;

    private void ExecuteRemoveImages(object? obj) => _imageService.RemoveIsValueImages();
    private bool CanExecuteRemoveImages(object? obj) => true;

    #endregion
    #region CommandSave

    internal readonly ICommand Save;

    private async void ExecuteSave(object? obj)
    {
        var images = _imageService.UpdateImagesFromCloudDisk();

        _repositoryE.Add(
            new NewsEntity(
                new TitleValidObject(Title),
                new DescriptionValidObject(Description!),
                DateOnly.Parse(Date),
                Category,
                new AuthorValidObject(Author!),
                await images)
            );

        _messageService.Message("Данные успешно добавились", TypeMessage.Info);
        _controlViewService.Exit();
    }

    private bool CanExecuteSave(object? obj) => ValidObject();

    #endregion

    public NewsAddingPanelViewModel(
        IRepository<NewsEntity> repositoryE, 
        IRepository<CategoryEntity> repositoryC, 
        IImageService imageService, 
        IMessageService messageService,
        IControlViewService controlViewService)
    {
        _repositoryE = repositoryE;
        _imageService = imageService;
        _messageService = messageService;
        _controlViewService = controlViewService;

        _imageService.BindingImages(this, nameof(Images));
        CategoryEntities = repositoryC.Get().ToArray();

        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
        RemoveImages = new ExecuteCommand(ExecuteRemoveImages, CanExecuteRemoveImages);
        AddImages = new ExecuteCommand(ExecuteAddImages, CanExecuteAddImages);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        ToggleImage = new ExecuteCommand(ExecuteToggleImage, CanExecuteToggleImage);
    }
}

