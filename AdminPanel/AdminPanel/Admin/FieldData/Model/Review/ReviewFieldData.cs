using DataAccess.Postgres.Models;
using UserInterface.Attribute;
using UserInterface.Interface;

namespace Admin.FieldData.Model.Review;

public class ReviewFieldData : IDataUi<ReviewEntity>
{
    [LinkingEntity(nameof(ReviewEntity.Rating))]
    public int Rating { get; set; }

    [LinkingEntity(nameof(ReviewEntity.Visitor))]
    public VisitorEntity? Visitor { get; set; }

    [LinkingEntity(nameof(ReviewEntity.Comment))]
    public string Comment { get; set; } = "";

    public ReviewEntity Entity
    {
        get;
        set
        {
            EntityId = value.Id;
            field = value;
        }
    }

    public long EntityId { get; set; }
}