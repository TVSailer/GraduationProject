using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.Service.MementoService.BaseMementoService;
using Domain.ValidObject;
using Teacher.ViewModel.Enter;

namespace Teacher.ViewModel.Teacher;

public class TeacherProfelPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IImageService _imageService;
    private readonly IRepository<TeacherEntity> _repositoryV;
    private readonly TeacherEntity _teacherEntity;

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
        var image = await _imageService.UpdateImageFromCloudDisk();

        _teacherEntity.UpdateImage(new ImageValidObject(image.CloudPath));
        _repositoryV.Update(_teacherEntity);
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

    public TeacherProfelPanelViewModel(
        IControlViewService controlViewService,
        IImageService imageService,
        IRepository<TeacherEntity> repositoryV,
        IMementoService<TeacherEntity> sharedService)
    {
        _controlViewService = controlViewService;
        _imageService = imageService;
        _repositoryV = repositoryV;

        _teacherEntity = sharedService.Get().Value;

        FIO = _teacherEntity.ToString();
        Image = _teacherEntity.Image;
        DateBurth = _teacherEntity.DateBirth;
        NumberPhone = _teacherEntity.NumberPhone;

        imageService.BindingImage(this, nameof(Image), _teacherEntity.Image);

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        ChangeAccount = new ExecuteCommand(ExecuteChangeAccount, CanExecuteChangeAccount);
    }
    
}