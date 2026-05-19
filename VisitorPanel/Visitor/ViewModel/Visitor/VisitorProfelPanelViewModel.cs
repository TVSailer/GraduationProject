using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MementoService.BaseMementoService;
using System.Windows.Input;
using Domain.Service.FielService.BaseFileService;
using Domain.ValidObject;
using Visitor.ViewModel.Enter;

namespace Visitor.ViewModel.Visitor;

public class VisitorProfelPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IImageFileService _imageFileService;
    private readonly IRepository<VisitorEntity> _repositoryV;
    private readonly VisitorEntity _visitorEntity;

    #region Property

    public string FIO;
    public string? Image
    {
        get => _imageFileService.GetFullPath(_visitorEntity.Image);
        set
        {
            if (value == field) return;
            Set(ref field, value);
            _visitorEntity.UpdateImage(new ImageValidObject(value));
            _repositoryV.Update(_visitorEntity);
        }
    }

    public string DateBurth { get; set; }
    public string NumberPhone { get; set; }

    #endregion
    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
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
        IImageFileService imageFileService,
        IRepository<VisitorEntity> repositoryV,
        IMementoService<VisitorEntity> sharedService)
    {
        _controlViewService = controlViewService;
        _imageFileService = imageFileService;
        _repositoryV = repositoryV;

        _visitorEntity = sharedService.Get().Value;

        FIO = _visitorEntity.ToString();
        Image = _visitorEntity.Image;
        DateBurth = _visitorEntity.DateBirth;
        NumberPhone = _visitorEntity.NumberPhone;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        ChangeAccount = new ExecuteCommand(ExecuteChangeAccount, CanExecuteChangeAccount);
    }

    public IEnumerable<string> GetDateAttendance() => _visitorEntity.DateAttendances.Select(d => d.ToString("dd/MM"));
    public IEnumerable<string[]> GetAttendace() => _visitorEntity.GetLessonWithAttendance();
}