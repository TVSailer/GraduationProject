using Admin.FieldData.AbstractFieldData;
using DataAccess.Postgres.Models;
using UserInterface.Attribute;
using Validaiger.AttributeValid;

namespace Admin.FieldData.Model.Visitor;

public class VisitorFieldData : FieldData<VisitorEntity>
{
    [LinkingEntity(nameof(VisitorEntity.FIO))]
    public FIO FIO
    {
        get => new (FIOVisitor);
        set => FIOVisitor = value.ToString();
    }

    [FIO]
    public string? FIOVisitor { get; set => ValidProperty(ref field, value); }

    [DateBirthday(8), LinkingEntity(nameof(VisitorEntity.DateBirth))]
    public string? DateBirth { get; set => ValidProperty(ref field, value); }

    [PhoneNumber, LinkingEntity(nameof(VisitorEntity.NumberPhone))]
    public string? NumberPhone { get; set => ValidProperty(ref field, value); }
}