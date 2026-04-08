using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;

namespace Visitor.View.Review;

public class ReviewCard : ObjectCard<ReviewEntity>
{
    public ReviewCard()
    {
        Height = 250;
        Dock = DockStyle.Top;
        Margin = new Padding(5);
    }

    public static string Rating(int rating)
    {
        return new string('★', rating) + new string('☆', 5 - rating);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row(15).Content().Label(Entity.Visitor.ToString()).Size(12).End()
            .Row(15).Content().Label(Entity.Date).Size(12).End()
            .Row(15).Content().Label(Rating((int)Entity.Rating)).ForeColor(Color.Orange).Size(16).End()
            .Row(55).Content().Label(Entity.Comment).Size(12).End();
}