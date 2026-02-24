using Admin.ViewModel.AbstractFieldData;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorFieldData : FieldData<VisitorEntity>
{
    [LinkingEntity(nameof(VisitorEntity.FIO))]
    public FIO FIO
    {
        get => new (FIOVisitor);
        set => FIOVisitor = value.ToString();
    }

    [LinkingEntity(nameof(VisitorEntity.AuthEntity))]
    public AuthEntity Auth
    {
        get
        {
            if (field != null) return field;
            return new AuthEntity()
                .CreateAuthUser(FIO, out var pas, out var log)
                .With(_ => LogicaMessage.MessageInfo($" Логин: {log}\nПароль: {pas}"));
        }
        set;
    }

    [FIO, BaseFieldUi("ФИО", "Введите ФИО")]
    public string? FIOVisitor { get; set => ValidProperty(ref field, value); }

    [DateBirthday, LinkingEntity(nameof(VisitorEntity.DateBirth)), DateFieldUi("Дата рождения", "dd.MM.yyyy")]
    public string DateBirth { get; set => ValidProperty(ref field, value); }

    [PhoneNumber, LinkingEntity(nameof(VisitorEntity.NumberPhone)), MaskedTextBoxFieldUi("Номер телефона", "+7 (000)-000-00-00")]
    public string NumberPhone { get; set => ValidProperty(ref field, value); }
}