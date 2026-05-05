using Domain.Command;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.EntityService.TeacherService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using System.Windows.Input;
using Domain.Service.FielService.BaseFileService;

namespace Admin.ViewModel.Teacher;

public class TeacherAddingPanelViewModel : General.ViewModel.ViewModel
{
    private readonly IImageFileService _imageFileService;
    private readonly IControlViewService _controlViewService;
    private readonly ITeacherService _teacherService;
    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday] public string? DateBirth { get; set => Set(ref field, value); } = DateTime.Now.ToString("dd/MM/yyyy");
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }
    [Image] public string? Image { get; set => Set(ref field, value); }

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandSave

    internal readonly ICommand Save;

    private void ExecuteSave(object? obj)
    {
        _teacherService.Add(
            new ImageValidObject(_imageFileService.SaveImageToDick(Image)),
            new NameValidObject(Name),
            new SurnameValidObject(Surname),
            new PatronymicValidObject(Patronymic),
            new DateBirthTeacherValidObject(DateOnly.Parse(DateBirth)),
            new NumberPhoneValidObject(NumberPhone));

        _controlViewService.Exit();
    }

    private bool CanExecuteSave(object? obj) => ValidObject();

    #endregion

    public TeacherAddingPanelViewModel(
        IImageFileService imageFileService,
        IControlViewService controlViewService, 
        ITeacherService teacherService)
    {
        _imageFileService = imageFileService;
        _controlViewService = controlViewService;
        _teacherService = teacherService;

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Save = new ExecuteCommand(ExecuteSave, CanExecuteSave);
    }
}