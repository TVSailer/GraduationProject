using CSharpFunctionalExtensions;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MementoService.BaseMementoService;
using Domain.ValidObject;
using System.Windows.Input;
using Visitor.ViewModel.Enter;

namespace Visitor.ViewModel.Visitor;

public class VisitorProfelPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IImageFileService _imageFileService;
    private readonly IImageService _imageService;
    private readonly IRepository<VisitorEntity> _repositoryV;
    private readonly VisitorEntity _visitorEntity;

    #region Property

    public string FIO;
    public string? Image { get; set => Set(ref field, value); }

    public string DateBurth { get; set; }
    public string NumberPhone { get; set; }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private async void ExecuteExit(object? obj)
    {
        var path = await _imageService.UpdateImageFromCloudDisk();

        _visitorEntity.UpdateImage(new ImageValidObject(path.CloudPath));
        _repositoryV.Update(_visitorEntity);
        _controlViewService.Exit();
    }

    private bool CanExecuteExit(object? obj) => true;

    #endregion

    #region CommandChangeAccount

    internal readonly ICommand ChangeAccount;

    private void ExecuteChangeAccount(object? obj)
    {
        _controlViewService.Exit();
        _controlViewService.ShowDialog<EnterPanelViewModel>();
    }

    private bool CanExecuteChangeAccount(object? obj) => true;

    #endregion

    public VisitorProfelPanelViewModel(
        IControlViewService controlViewService,
        IImageService imageService,
        IRepository<VisitorEntity> repositoryV,
        IMementoService<VisitorEntity> sharedService)
    {
        _controlViewService = controlViewService;
        _imageService = imageService;
        _repositoryV = repositoryV;

        _visitorEntity = sharedService.Get().Value;

        FIO = _visitorEntity.ToString();
        DateBurth = _visitorEntity.DateBirth;
        NumberPhone = _visitorEntity.NumberPhone;

        imageService.BindingImage(this, nameof(Image), _visitorEntity.Image);

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        ChangeAccount = new ExecuteCommand(ExecuteChangeAccount, CanExecuteChangeAccount);
    }

    public IEnumerable<string> GetDateAttendance() => _visitorEntity.DateAttendances.Select(d => d.ToString("dd/MM"));
    public IEnumerable<string[]> GetAttendace() => _visitorEntity.GetLessonWithAttendance();
}