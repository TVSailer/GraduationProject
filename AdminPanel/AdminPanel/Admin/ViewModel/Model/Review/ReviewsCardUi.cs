using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.Review;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Review.Buttons;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.ViewModel.Model.Review;

public class ReviewsCardUi(
    MementoLesson repository,
    ReviewManagment viewData,
    ReviewManagmentButton parametersButtons)
    : View<ReviewManagment>
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
            .Row()
            .ContentEnd(new CardLayoutPanel<ReviewEntity, ReviewCard>()
                .SetClickedCard(parametersButtons)
                .SetObjects(repository.GetReviews()))
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<ReviewManagment>>()
                .SetClickedData(this, new ViewButtonClickArgs<ReviewManagment>(viewData))
                .SetButtons(parametersButtons))
            .Build();
    }
}