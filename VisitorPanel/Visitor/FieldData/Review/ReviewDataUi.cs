using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.Models;
using System.Runtime.CompilerServices;
using Extension_Func_Library;
using UserInterface;
using UserInterface.Attribute;
using UserInterface.GenericEntity;
using UserInterface.Interface;
using Validaiger;
using Validaiger.AttributeValid;
using Visitor.Enum;

namespace Visitor.FieldData.Review;

public class ReviewDataUi : PropertyChange, IDataUi<ReviewEntity>
{
    [RequiredCustom]
    [LinkingEntity(nameof(ReviewEntity.Rating))]
    public Estimation Estimation { get; set => ValidProperty(ref field, value); }
    [RequiredCustom]
    [LinkingEntity(nameof(ReviewEntity.Comment))]
    public string? Comment { get; set => ValidProperty(ref field, value); }
    [RequiredCustom]
    [LinkingEntity(nameof(ReviewEntity.Visitor))]
    public VisitorEntity? Visitor { get; set => ValidProperty(ref field, value); }
    [RequiredCustom]
    [LinkingEntity(nameof(ReviewEntity.Visitor))]
    public LessonEntity? Lesson { get; set => ValidProperty(ref field, value); }

    public ReviewEntity Entity
    {
        get => MementoEntity.GetEntityNotNull();
        set => MementoEntity.SetEntity(value.Id, value);
    }

    public long EntityId
    {
        get => MementoEntity.Id;
        set => throw new NotImplementedException();
    }

    protected MementoEntity<ReviewEntity> MementoEntity
    {
        get
        {
            field ??= new MementoEntity<ReviewEntity>(this);
            return field;
        }
    }

    public T ValidProperty<T>(ref T field, T value, [CallerMemberName] string prop = "")
    {
        OnPropertyChanged(ref field, value, prop);
        Validatoreg.TryValidProperty(value!, prop, this, out var errorMessage);
        OnMassageErrorProvider(errorMessage, prop);
        return value;
    }

    public bool ValidObject(Action<long, ReviewEntity> action)
    {
        if (Validatoreg.TryValidObject(this, out var results))
        {
            action.Invoke(MementoEntity.Id, Entity);
            return true;
        }

        results.ForEach(r => r.MemberNames.ForEach(m => OnMassageErrorProvider(r.ErrorMessage, m)));
        return false;
    }
}