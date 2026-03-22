using Admin.DI.Module;
using Admin.FieldData.Model.Review.Buttons;
using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
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
                .Initialize(repository.Lesson!.Reviews.ToArray()))
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(parametersClickeds.GetButtons(new ClickedArgs<ReviewManager>(DataUi))).End();
}