using Admin.DI.Module;
using Admin.FieldData.Model.Teacher;
using Admin.ViewModel.Model.Review.Buttons;
using DataAccess.PostgreSQL.Repository;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.View;

namespace Admin.View.Moduls.Review;

public class ReviewsCardUi(
    MementoLesson repository,
    ReviewManagerClicked parametersClickeds)
    : UiView<ReviewManager>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row()
            .ContentEnd(new CardFlowPanel<ReviewEntity, ReviewCard>()
                .SetClickedCard(parametersClickeds)
                .Initialize(repository.GetReviews().ToArray()))
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersClickeds.GetButtons(DataUi)));
}