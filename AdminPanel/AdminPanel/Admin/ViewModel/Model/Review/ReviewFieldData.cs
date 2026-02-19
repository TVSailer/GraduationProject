using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Model.Review;

public class ReviewDetailsFieldData : IFieldData<ReviewEntity>
{
    public GenericRepositoryEntity<ReviewEntity> Entity { get; set; } = new();

    [LinkingEntity(nameof(ReviewEntity.Rating))]
    [ReadOnlyFieldUi("Рейтинг: ")]
    public int Rating { get; set; }

    [LinkingEntity(nameof(ReviewEntity.Visitor))]
    [ReadOnlyFieldUi("Автор: ")]
    public VisitorEntity Visitor { get; set; }

    [LinkingEntity(nameof(ReviewEntity.Comment))]
    [ReadOnlyMultilineFieldUi("Комментарий: ")]
    public string Comment { get; set; } = "";

    public ReviewDetailsFieldData()
    {
        Entity.Initialize(this);
    }
}