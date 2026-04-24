using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using System.Windows.Input;

namespace Admin.ViewModel.Visitor;

public class VisitorAddingPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IAuthService _authService;
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly IControlViewService _controlViewService;
    private readonly ISharedService _sharedService;
    private readonly LessonEntity _lessonEntity;

    [Name] public string? Name { get; set => Set(ref field, value); } = "";
    [Surname] public string? Surname { get; set => Set(ref field, value); } = "";
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); } = "";
    [DateBirthday(10)] public string? DateBirth { get; set => Set(ref field, value); } = DateTime.Now.ToShortDateString();
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); } = "";

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj)
    {
        _sharedService.SetData(_lessonEntity);
        _controlViewService.Exit();
    }

    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandSave

    internal readonly ICommand Save;

    private void ExecuteSave(object? obj)
    {
        var visitor = new VisitorEntity(
            new NameValidObject(Name),
            new SurnameValidObject(Surname),
            new PatronymicValidObject(Patronymic),
            new DateBirthVisitorValidObject(DateOnly.Parse(DateBirth)),
            new NumberPhoneValidObject(NumberPhone),
            _authService.CreateAuth(Surname, UserRole.Visitor));

        _lessonEntity.AddVisitor(visitor);
        _repositoryL.Update(_lessonEntity);
        _authService.MessageAuth();

        _sharedService.SetData(_lessonEntity);
        _controlViewService.Exit();
    }

    private bool CanExecuteSave(object? obj) => ValidObject();

    #endregion

    public VisitorAddingPanelViewModel(
        IAuthService authService,
        IRepository<LessonEntity> repositoryL,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        _lessonEntity = sharedService.GetData<LessonEntity>();

        _authService = authService;
        _repositoryL = repositoryL;
        _controlViewService = controlViewService;
        _sharedService = sharedService;

        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}