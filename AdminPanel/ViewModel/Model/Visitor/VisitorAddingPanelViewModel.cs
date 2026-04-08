using System.Windows.Input;
using Domain.Command;
using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.MessageService.BaseMessageService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorAddingPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IMessageService _messageService;
    private readonly IRepository<LessonEntity> _repositoryL;
    private readonly IRepository<AuthEntity> _repositoryA;
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
        var login = LoginValidObject.Create(Surname);
        var password = PasswordValidObject.Create(
            _repositoryA
                .Get()
                .Select(a => a.Password)
                .ToArray());

        _lessonEntity.Visitors.Add(
            new VisitorEntity(
                NameValidObject.Create(Name), 
                SurnameValidObject.Create(Surname), 
                PatronymicValidObject.Create(Patronymic), 
                DateBirthVisitorValidObject.Create(DateOnly.Parse(DateBirth)), 
                NumberPhoneValidObject.Create(NumberPhone), 
                new AuthEntity(login, password)));

        _repositoryL.Update(_lessonEntity);

        _messageService.Message(
            $"Логин: {login}" +
            $"\n" +
            $"Пароль: {password.Password}", TypeMessage.Info);

        _sharedService.SetData(_lessonEntity);
        _controlViewService.Exit();
    }

    private bool CanExecuteSave(object? obj) => ValidObject();

    #endregion

    public VisitorAddingPanelViewModel(
        IRepository<LessonEntity> repositoryL,
        IRepository<AuthEntity> repositoryA,
        IMessageService messageService,
        IControlViewService controlViewService,
        ISharedService sharedService)
    {
        _lessonEntity = sharedService.GetData<LessonEntity>();

        _repositoryL = repositoryL;
        _repositoryA = repositoryA;
        _messageService = messageService;
        _controlViewService = controlViewService;
        _sharedService = sharedService;

        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
    }
}