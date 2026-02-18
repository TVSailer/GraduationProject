using Admin.DI;
using Admin.View.Moduls.Review;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.Lesson;

public class LessonReviewCardUi(VisitorsLessonRepository repositoryV) : View<LessonReviewManagment>
{
    protected override Control? CreateUi()
        => LayoutPanel.CreateColumn()
            .Row().ContentEnd(new CardLayoutPanel<ReviewEntity, ReviewCard>()
                .SetObjects(repositoryV.Lesson.Reviews))
            .Build();
}