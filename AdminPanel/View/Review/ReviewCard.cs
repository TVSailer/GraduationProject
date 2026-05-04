using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;

namespace Admin.View.Review;

public class ReviewCard : ObjectCard<ReviewEntity>
{
    public ReviewCard()
    {
        Size = new Size(350, 80);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content().Label(Entity.Date).ForeColor(Color.DarkBlue).End()
            .Row().Content().Label(Entity.Visitor.ToString()).ForeColor(Color.Gray).End()
            .Row().Content().Label($"★ {(int)Entity.RatingId}").ForeColor(Color.Orange).End();
}