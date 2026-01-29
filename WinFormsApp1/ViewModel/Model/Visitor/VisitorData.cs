using Admin.View;
using Admin.View.Moduls.Visitor;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica;
using Logica.CustomAttribute;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorData : ViewModele<VisitorEntity>
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


    public VisitorData() : base(new MainCommand(_ => AdminDI.GetService<ManagementView<VisitorEntity, VisitorCard>>().InitializeComponents(null)))
    {

    }
}