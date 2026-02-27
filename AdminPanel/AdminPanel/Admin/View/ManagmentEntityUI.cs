using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica.Message;
using User_Interface_Library.LayerPanel;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.UiLayoutPanel.CardPanel;
using User_Interface_Library.UiLayoutPanel.CardPanel.Args;
using User_Interface_Library.UiLayoutPanel.SearchCardPanel;
using User_Interface_Library.UiLayoutPanel.SearchPanel;
using User_Interface_Library.View;

namespace Admin.View;

public class ManagmentEntityUi<T, TEntity, TFieldSearch, TCard, TButtons>(
    T viewData,
    TButtons parametersButtons,
    TFieldSearch fieldSearch,
    Repository<TEntity> repository) : UiView<T> 
    where TEntity : new()
    where TFieldSearch : SearchFieldData<TEntity>
    where TCard : ObjectCard<TEntity>, new()
    where TButtons : IButtons<T>, IButtons<CardClickedToolStripArgs<TEntity>>, IButton<CardClickedArgs<TEntity>>
{
    protected override Control CreateUi()
    {
        var layout = LayoutPanel.CreateColumn()
            .Row().ContentEnd(new SearchCardPanel<TEntity, TFieldSearch, TCard>(fieldSearch, repository.Get().ToArray())
                .SetClickedPanel(parametersButtons)
                .SetContextMenu(parametersButtons))
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(parametersButtons.GetButtons(viewData)))
            .Build();

        return layout;
    }
}