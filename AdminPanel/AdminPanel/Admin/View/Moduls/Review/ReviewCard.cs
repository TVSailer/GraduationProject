using Logica.UILayerPanel;

namespace Admin.View.Moduls.Review;

public class ReviewCard : ObjectCard<ReviewEntity>
{
    public override Control Content()
        => LayoutPanel.CreateColumn()
            .Row().ContentEnd(FactoryElements.Label_11(entity.Rating.ToString()))
            .Row().ContentEnd(FactoryElements.Label_11(entity.Date))
            .Row().ContentEnd(FactoryElements.Label_11(entity.Visitor.ToString()))
            .Row().ContentEnd(FactoryElements.Label_11(entity.Comment))
            .Build();
}