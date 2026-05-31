using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using System.Windows.Input;

namespace Admin.ViewModel.News;


public class NewsDetailsPanelViewModel : General.ViewModel.ViewModel
{
    internal readonly IImageService _imageService;
    private readonly IMessageService _messageService;

    private readonly IRepository<NewsEntity> _repositoryN;
    private readonly IControlViewService _controlViewService;
    private readonly NewsEntity _newsEntity;

    public readonly CategoryEntity[] CategoryEntities;

    #region Property

    [Title] public string? Title { get; set => Set(ref field, value); }
    [Description] public string? Description { get; set => Set(ref field, value); }
    [Date] public string? Date { get; set => Set(ref field, value); }
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

    private void ExecuteRemoveImages(object? obj)
    {
        _imageService.UpdateListImages();
    }

    private bool CanExecuteRemoveImages(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;

    private async void ExecuteUpdate(object? obj)
    {
        var images = _imageService.UpdateImagesFromCloudDisk();

        _newsEntity
            .UpdateTitle(new TitleValidObject(Title))
            .UpdateContent(new DescriptionValidObject(Description))
            .UpdateAuthor(new AuthorValidObject(Author))
            .UpdateDate(DateOnly.Parse(Date))
            .UpdateCategory(Category)
            .UpdateImages(await images);

        _repositoryN.Update(_newsEntity);

        _messageService.Message("Данные успешно обновились", TypeMessage.Info);
    }

    private bool CanExecuteUpdate(object? obj)
        => _messageService.Message("Данные безвозратно изменяться!", TypeMessage.YesCancel) == TypeCommandMessage.Yes && ValidObject();

    #endregion
    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _imageService.ClearImages();
        _repositoryN.Delete(_newsEntity.Id);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj)
        => _messageService.Message("Выдействительно хотите удалить?", TypeMessage.YesCancel) is TypeCommandMessage.Yes;

    #endregion
    public NewsDetailsPanelViewModel(
        IRepository<NewsEntity> repositoryN, 
        IRepository<CategoryEntity> repositoryC, 
        IImageService imageService, 
        IMessageService messageService,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        _repositoryN = repositoryN;
        _imageService = imageService;
        _messageService = messageService;
        _controlViewService = controlViewService;
        CategoryEntities = repositoryC.Get().ToArray();

        _newsEntity = sharedService.GetData<NewsEntity>();

        Title = _newsEntity.Title;
        Category = _newsEntity.Category;
        Description = _newsEntity.Content;
        Date = _newsEntity.Date;
        Author = _newsEntity.Author;

        _imageService.BindingImages(this, nameof(Images), _newsEntity.Images.Select(i => i.Url));

        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        RemoveImages = new ExecuteCommand(ExecuteRemoveImages, CanExecuteRemoveImages);
        AddImages = new ExecuteCommand(ExecuteAddImages, CanExecuteAddImages);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
        ToggleImage = new ExecuteCommand(ExecuteToggleImage, CanExecuteToggleImage);
    }
}