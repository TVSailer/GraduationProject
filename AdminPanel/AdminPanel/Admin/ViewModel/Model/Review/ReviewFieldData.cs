using Admin.ViewModel.GenericEntity;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Model.Review;

public class ReviewFieldData : IFieldData<ReviewEntity>
{
    public GenericRepositoryEntity<ReviewEntity> MementoEntity { get; set; } = new();

    [LinkingEntity(nameof(ReviewEntity.Rating))]
    [ReadOnlyFieldUi("Рейтинг: ")]
    public int Rating { get; set; }

    [LinkingEntity(nameof(ReviewEntity.Visitor))]
    [ReadOnlyFieldUi("Автор: ")]
    public VisitorEntity? Visitor { get; set; }

    [LinkingEntity(nameof(ReviewEntity.Comment))]
    [ReadOnlyMultilineFieldUi("Комментарий: ")]
    public string Comment { get; set; } = "";

    public ReviewFieldData()
    {
        MementoEntity.Initialize(this);
    }
}