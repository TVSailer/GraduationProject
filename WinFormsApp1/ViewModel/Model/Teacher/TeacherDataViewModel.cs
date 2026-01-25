using System.Windows.Input;
using Admin.View;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using WinFormsApp1;

public abstract class TeacherData : ViewModele<TeacherEntity>
{
    [LinkingEntity(nameof(TeacherEntity.FIO))]
    public FIO FIO
    {
        get => FIO.TryValidFIO(FIOTeacher) ? new FIO(FIOTeacher) : throw new ArgumentNullException();
        set => FIOTeacher = value.ToString();
    }

    [FIO, BaseFieldUi("ФИО", "Введите ФИО преподователя")] 
    public string? FIOTeacher
    {
        get;
        set => TryValidProperty(ref field, value);
    }

    [DateBirthday, LinkingEntity(nameof(TeacherEntity.DateBirth)) , DateFieldUi("Дата рождения", CustomFormatDatePicker.dd_MM_yyyy)] 
    public string DateBirth { get; set => TryValidProperty(ref field, value); }

    [PhoneNumber, LinkingEntity(nameof(TeacherEntity.NumberPhone)), MaskedTextBoxFieldUi("Номер телефона", "+7 (000)-000-00-00")] 
    public string NumberPhone { get; set => TryValidProperty(ref field, value); }

    public TeacherData(TeacherRepository teacherRepository, LessonsRepository lessonsRepository) : base(
        new MainCommand(_ => AdminDI.GetService<ManagementView<TeacherEntity, TeacherCard>>().InitializeComponents(null)))
    {
        
    }
}
