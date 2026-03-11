using Extension_Func_Library;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Admin.View.Moduls.Review;

public class ReviewCard : ObjectCard<ReviewEntity>
{
    public ReviewCard()
    {
        Size = new Size(350, 80);
    }

    public override Control Content()
        => new BuilderLayoutPanel().Column()
            .Row().ContentEnd(FactoryElements.Label_11(Entity.Date).With(l => l.ForeColor = Color.DarkBlue))
            .Row().ContentEnd(FactoryElements.Label_11(Entity.Visitor.ToString()).With(l => l.ForeColor = Color.Gray))
            .Row().ContentEnd(FactoryElements.Label_11($"★ {Entity.Rating.ToString()}").With(l => l.ForeColor = Color.Orange))
            .Build();
}