using Logica.UILayerPanel;

namespace Admin.View.Moduls.Review;

public class ReviewCard : ObjectCard<ReviewEntity>
{
    public ReviewCard() 
    {
        Size = new Size(400, 130);
    }

    public override Control Content()
        => LayoutPanel.CreateColumn()
            .Row().ContentEnd(FactoryElements.Label_11(entity.Date).With(l => l.ForeColor = Color.DarkBlue))
            .Row().ContentEnd(FactoryElements.Label_11(entity.Visitor.ToString()).With(l => l.ForeColor = Color.Gray))
            .Row().ContentEnd(FactoryElements.Label_11($"★ {entity.Rating.ToString()}").With(l => l.ForeColor = Color.Orange))
            .Build();
}