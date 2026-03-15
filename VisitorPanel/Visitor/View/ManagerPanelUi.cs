using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Visitor.View;

public class ManagerPanelUi<TDataUi, TEntity, TCard, TButtons>(TDataUi dataUi, Repository<TEntity> repository, TButtons clickeds) : UiView<TDataUi>
    where TButtons : IButtons<ClickedArgs<TDataUi>>, IClicked<CardClickedArgs<TEntity>>
    where TCard : ObjectCard<TEntity>, new()
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .CardFlowLayoutPanel<TEntity, TCard>(repository.Get().ToArray())
                .ClickedCard(clickeds)
                .Initialize()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(clickeds.GetButtons(new ClickedArgs<TDataUi>(dataUi))).End();
}