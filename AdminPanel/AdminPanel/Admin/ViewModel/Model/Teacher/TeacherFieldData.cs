using Admin.ViewModel.AbstractFieldData;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;

namespace Admin.ViewModel.Model.Teacher;

public class TeacherFieldData : FieldData<TeacherEntity>
{
    [LinkingEntity(nameof(TeacherEntity.FIO))]
    public FIO FIO
    {
        get => new (FIOTeacher);
        set => FIOTeacher = value.ToString();
    }

    [LinkingEntity(nameof(TeacherEntity.AuthEntity))]
    public AuthEntity? Auth
    {
        get
        {
            if(field != null) return field;
            return new AuthEntity()
                .CreateAuthUser(FIO, out string pas, out var log)
                .With(_ => LogicaMessage.MessageInfo($" Логин: {log}\nПароль: {pas}"));
        }
        set;
    }

    [FIO, BaseFieldUi("ФИО", "Введите ФИО преподователя")] 
    public string? FIOTeacher { get; set => ValidProperty(ref field, value); }

    [DateBirthday, LinkingEntity(nameof(TeacherEntity.DateBirth)) , DateFieldUi("Дата рождения", "dd.MM.yyyy")] 
    public string? DateBirth { get; set => ValidProperty(ref field, value); }

    [PhoneNumber, LinkingEntity(nameof(TeacherEntity.NumberPhone)), MaskedTextBoxFieldUi("Номер телефона", "+7 (000)-000-00-00")] 
    public string? NumberPhone { get; set => ValidProperty(ref field, value); }
}