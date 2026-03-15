using DataAccess.PostgreSQL.Extensions;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.UiLayoutPanel.SearchCardPanel;
using UserInterface.View;

namespace Admin.View;

public class ManagerEntityUi<T, TEntity, TFieldSearch, TCard, TButtons>(
    TButtons parametersButtons,
    TFieldSearch fieldSearch,
    Repository<TEntity> repository) : UiView<T>
    where TEntity : new()
    where TFieldSearch : SearchFieldData<TEntity>
    where TCard : ObjectCard<TEntity>, new()
    where TButtons : IButtons<T>, IToolStrip<TEntity>, IClicked<TEntity>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.Column()
            .Row().ContentEnd(new SearchCardPanel<TEntity, TFieldSearch, TCard>(fieldSearch)
                .SetClickedPanel(parametersButtons)
                .SetContextMenu(parametersButtons)
                .Initialize(repository.Get().ToArray()))
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(parametersButtons.GetButtons(new ClickedArgs<T>(DataUi))).End();
}