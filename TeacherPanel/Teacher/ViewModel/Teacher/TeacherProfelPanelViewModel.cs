using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MementoService.BaseMementoService;
using Domain.ValidObject;
using Teacher.ViewModel.Enter;

namespace Teacher.ViewModel.Teacher;

public class TeacherProfelPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IControlViewService _controlViewService;
    private readonly IRepository<TeacherEntity> _repositoryV;
    private readonly TeacherEntity _teacherEntity;

    #region Property

    public string FIO;
    public string? Image
    {
        get;
        set
        {
            if (value == field) return;
            Set(ref field, value);
            _teacherEntity.UpdateImage(ImageValidObject.Create(value));
            _repositoryV.Update(_teacherEntity);
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

    public TeacherProfelPanelViewModel(
        IControlViewService controlViewService,
        IRepository<TeacherEntity> repositoryV,
        IMementoService<TeacherEntity> sharedService)
    {
        _controlViewService = controlViewService;
        _repositoryV = repositoryV;

        _teacherEntity = sharedService.Get().Value;

        FIO = _teacherEntity.ToString();
        Image = _teacherEntity.Image;
        DateBurth = _teacherEntity.DateBirth;
        NumberPhone = _teacherEntity.NumberPhone;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        ChangeAccount = new ExecuteCommand(ExecuteChangeAccount, CanExecuteChangeAccount);
    }
    
}