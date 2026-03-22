using CSharpFunctionalExtensions;
using System.Runtime.CompilerServices;
using DataAccess.PostgreSQL.Enum;
using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using ExtensionFunc;
using UserInterface;
using UserInterface.Attribute;
using UserInterface.GenericEntity;
using UserInterface.Interface;
using Validaiger;
using Validaiger.AttributeValid;

namespace Visitor.FieldData.Review;

public class ReviewDataUi(MementoVisitor mementoVisitor, MementoLesson mementoLesson) : ViewModel, IDataUi<ReviewEntity>
{
    [RequiredCustom]
    [LinkingEntity(nameof(ReviewEntity.Rating))]
    public Estimation Estimation
    {
        get;
        set => ValidProperty(ref field, value);
    }

    [RequiredCustom]
    [LinkingEntity(nameof(ReviewEntity.Comment))]
    public string? Comment
    {
        get;
        set => ValidProperty(ref field, value);
    }

    [LinkingEntity(nameof(ReviewEntity.Visitor))]
    public VisitorEntity Visitor
    {
        get => mementoVisitor.Visitor;
    }

    [LinkingEntity(nameof(ReviewEntity.Lesson))]
    public LessonEntity Lesson
    {
        get => mementoLesson.Lesson;
    }

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
        Set(ref field, value, prop);
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