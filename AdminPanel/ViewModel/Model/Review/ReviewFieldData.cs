using Admin.FieldData.AbstractFieldData;
using DataAccess.PostgreSQL.ModelsPrimitive;
using UserInterface.Attribute;

namespace Admin.FieldData.Model.Review;

public class ReviewFieldData : FieldData<ReviewEntity>
{
    [LinkingEntity(nameof(ReviewEntity.Rating))]
    public int Rating { get; set => Set(ref field, value); }

    [LinkingEntity(nameof(ReviewEntity.Visitor))]
    public VisitorEntity? Visitor { get; set => Set(ref field, value); }

    [LinkingEntity(nameof(ReviewEntity.Comment))]
    public string? Comment { get; set => Set(ref field, value); }
}