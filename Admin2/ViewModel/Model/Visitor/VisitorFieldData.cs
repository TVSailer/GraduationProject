using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica.CustomAttribute;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorFieldData : FieldData<VisitorEntity>
{
    [LinkingEntity(nameof(VisitorEntity.FIO))]
    public FIO FIO
    {
        get => FIO.TryValidFIO(FIOVisitor) ? new FIO(FIOVisitor) : throw new ArgumentNullException();
        set => FIOVisitor = value.ToString();
    }

    [FIO, BaseFieldUi("ФИО", "Введите ФИО")]
    public string? FIOVisitor
    {
        get;
        set => TryValidProperty(ref field, value);
    }

    [DateBirthday, LinkingEntity(nameof(VisitorEntity.DateBirth)), DateFieldUi("Дата рождения", CustomFormatDatePicker.dd_MM_yyyy)]
    public string DateBirth { get; set => TryValidProperty(ref field, value); }

    [PhoneNumber, LinkingEntity(nameof(VisitorEntity.NumberPhone)), MaskedTextBoxFieldUi("Номер телефона", "+7 (000)-000-00-00")]
    public string NumberPhone { get; set => TryValidProperty(ref field, value); }
}