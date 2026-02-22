using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica.CustomAttribute;

public class TeacherFieldData : FieldData<TeacherEntity>
{
    [LinkingEntity(nameof(TeacherEntity.FIO))]
    public FIO FIO
    {
        get => FIO.TryValidFIO(FIOTeacher) ? new FIO(FIOTeacher) : throw new ArgumentNullException();
        set => FIOTeacher = value.ToString();
    }

    [FIO, BaseFieldUi("ФИО", "Введите ФИО преподователя")] 
    public string? FIOTeacher { get; set => TryValidProperty(ref field, value); }

    [DateBirthday, LinkingEntity(nameof(TeacherEntity.DateBirth)) , DateFieldUi("Дата рождения", "dd.MM.yyyy")] 
    public string DateBirth { get; set => TryValidProperty(ref field, value); }

    [PhoneNumber, LinkingEntity(nameof(TeacherEntity.NumberPhone)), MaskedTextBoxFieldUi("Номер телефона", "+7 (000)-000-00-00")] 
    public string NumberPhone { get; set => TryValidProperty(ref field, value); }
}