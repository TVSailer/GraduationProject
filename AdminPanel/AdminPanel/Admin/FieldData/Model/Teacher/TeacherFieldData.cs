using Admin.FieldData.AbstractFieldData;
using DataAccess.Postgres.Models;
using UserInterface.Attribute;
using Validaiger.AttributeValid;

namespace Admin.FieldData.Model.Teacher;

public class TeacherFieldData : FieldData<TeacherEntity>
{
    [LinkingEntity(nameof(TeacherEntity.FIO))]
    public FIO FIO
    {
        get => new (FIOTeacher); 
        set => FIOTeacher = value.ToString();
    }

    [FIO] 
    public string? FIOTeacher { get; set => ValidProperty(ref field, value); }

    [DateBirthday, LinkingEntity(nameof(TeacherEntity.DateBirth))] 
    public string? DateBirth { get; set => ValidProperty(ref field, value); }

    [PhoneNumber, LinkingEntity(nameof(TeacherEntity.NumberPhone))] 
    public string? NumberPhone { get; set => ValidProperty(ref field, value); }
}