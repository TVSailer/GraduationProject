using Domain.Command;
using Domain.Entitys;
using Domain.Service.ControlViewService.BaseControlView;
using Domain.Service.EntityService.TeacherService;
using Domain.Service.SharedService.BaseSharedService;
using Domain.Valid.AttributeValid;
using Domain.ValidObject;
using System.Windows.Input;
using Domain.Service.FielService.BaseFileService;

namespace Admin.ViewModel.Teacher;

public class TeacherDetailsPanelViewModel : General.ViewModel.ViewModel
{
    private readonly ITeacherService _teacherService;
    private readonly IControlViewService _controlViewService;
    private readonly IImageFileService _imageFileService;
    private readonly TeacherEntity _teacher;

    #region Property

    [Name] public string? Name { get; set => Set(ref field, value); }
    [Surname] public string? Surname { get; set => Set(ref field, value); }
    [Patronymic] public string? Patronymic { get; set => Set(ref field, value); }
    [DateBirthday] public string? DateBirth { get; set => Set(ref field, value); }
    [PhoneNumber] public string? NumberPhone { get; set => Set(ref field, value); }
    [Image] public string? Image
    {
        get;
        set
        {
            _imageFileService.DeleteImageFromDisk(field);
            Set(ref field, value);
        }
    }

    #endregion

    #region CommandExit

    internal readonly ICommand Exit;

    private void ExecuteExit(object? obj) => _controlViewService.Exit();
    private bool CanExecuteExit(object? obj) => true;

    #endregion
    #region CommandUpdate

    internal readonly ICommand Update;
    private void ExecuteUpdate(object? obj)
    {
        _teacher
            .UpdateImage(new ImageValidObject(_imageFileService.SaveImageToDick(Image)))
            .UpdateName(new NameValidObject(Name))
            .UpdateSurname(new SurnameValidObject(Surname))
            .UpdatePatronymic(new PatronymicValidObject(Patronymic))
            .UpdateDateBirth(new DateBirthTeacherValidObject(DateOnly.Parse(DateBirth)))
            .UpdateNumberPhone(new NumberPhoneValidObject(NumberPhone));

        _teacherService.Update(_teacher);
        _controlViewService.Exit();
    }
    private bool CanExecuteUpdate(object? obj) => ValidObject();

    #endregion
    #region CommandDelete

    internal readonly ICommand Delete;

    private void ExecuteDelete(object? obj)
    {
        _teacherService.ExecuteDelete(_teacher);
        _controlViewService.Exit();
    }

    private bool CanExecuteDelete(object? obj) 
        => _teacherService.CanExecuteDelete(_teacher);

    #endregion

    public TeacherDetailsPanelViewModel(
        ITeacherService teacherService,
        IControlViewService controlViewService,
        IImageFileService imageFileService,
        ISharedService sharedService)
    {
        _teacherService = teacherService;
        _controlViewService = controlViewService;
        _imageFileService = imageFileService;

        _teacher = sharedService.GetData<TeacherEntity>();

        Name = _teacher.Name;
        Surname = _teacher.Surname;
        Patronymic = _teacher.Patronymic;
        NumberPhone = _teacher.NumberPhone;
        DateBirth = _teacher.DateBirth;
        Image = imageFileService.GetFullPath(_teacher.Image);

        Exit = new ExecuteCommand(ExecuteExit, CanExecuteExit);
        Update = new ExecuteCommand(ExecuteUpdate, CanExecuteUpdate);
        Delete = new ExecuteCommand(ExecuteDelete, CanExecuteDelete);
    }

    public IEnumerable<object[]> GetDataGridLesson() 
        => _teacher.Lessons.Select(lesson => (object[])[lesson.Title, lesson.Location]);
}
