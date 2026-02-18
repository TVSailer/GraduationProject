using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Model.Review;

public class ReviewFieldData : IFieldData<ReviewEntity>
{
    public GenericRepositoryEntity<ReviewEntity> Entity { get; set; } = new();

    [LinkingEntity(nameof(ReviewEntity.Rating))]
    [BaseFieldUi("Рейтинг")]
    public int Rating { get; set; }

    [LinkingEntity(nameof(ReviewEntity.Comment))]
    [BaseFieldUi("Комментарий")]
    public string Comment { get; set; } = "";

    [LinkingEntity(nameof(ReviewEntity.Visitor))]
    [BaseFieldUi("Автор")]
    public VisitorEntity Visitor { get; set; }

    public ReviewFieldData()
    {
        Entity.Initialize(this);
    }
}