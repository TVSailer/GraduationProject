using Logica.UILayerPanel;

namespace Admin.View.Moduls.Review;

public class ReviewCard : ObjectCard<ReviewEntity>
{
    public override Control Content()
        => LayoutPanel.CreateColumn()
            .Row().ContentEnd(FactoryElements.Label_11(Entity.Date).With(l => l.ForeColor = Color.DarkBlue))
            .Row().ContentEnd(FactoryElements.Label_11(Entity.Visitor.ToString()).With(l => l.ForeColor = Color.Gray))
            .Row().ContentEnd(FactoryElements.Label_11($"★ {Entity.Rating.ToString()}").With(l => l.ForeColor = Color.Orange))
            .Build();
}