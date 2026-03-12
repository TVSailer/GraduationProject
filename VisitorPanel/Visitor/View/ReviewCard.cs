using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Visitor.View;

public class ReviewCard : ObjectCard<ReviewEntity>
{
    public ReviewCard()
    {
        Height = 200;
    }

    public override Control Content()
        => new BuilderLayoutPanel().Column()
            .Row(10).Content().Label(Entity.Visitor.FIO.ToString()).End()
            .Row(10).Content().Label(Entity.Date).End()
            .Row(10).Content().Label(Rating(Entity.Rating)).End()
            .Row(70).Content().Label(Entity.Comment).End()
            .Build();

    public static string Rating(int rating)
        => new string('★', rating) + new string('☆', rating);
}