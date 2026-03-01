using DataAccess.Postgres.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.UiLayoutPanel.SearchCardPanel;
using UserInterface.View;

namespace Admin.View;

public class ManagerEntityUi<T, TEntity, TFieldSearch, TCard, TButtons>(
    T viewData,
    TButtons parametersButtons,
    TFieldSearch fieldSearch,
    Repository<TEntity> repository) : UiView<T>
    where TEntity : new()
    where TFieldSearch : SearchFieldData<TEntity>
    where TCard : ObjectCard<TEntity>, new()
    where TButtons : IButtons<T>, IButtons<CardClickedToolStripArgs<TEntity>>, IButton<CardClickedArgs<TEntity>>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.CreateColumn()
            .Row().ContentEnd(new SearchCardPanel<TEntity, TFieldSearch, TCard>(fieldSearch)
                .SetClickedPanel(parametersButtons)
                .SetContextMenu(parametersButtons)
                .Initialize(repository.Get().ToArray()))
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersButtons.GetButtons(DataUi)));
}