using System.Windows.Forms;
using Extension_Func_Library;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.UiLayoutPanel.CardPanel;
using User_Interface_Library.UiLayoutPanel.CardPanel.Args;

namespace User_Interface_Library.UiLayoutPanel.SearchCardPanel;

public class SearchCardPanel<TEntity, TFieldSearch, TCard> : Panel
    where TFieldSearch : SearchFieldData<TEntity>
    where TEntity : new()
    where TCard : ObjectCard<TEntity>, new()
{
    private readonly CardLayoutPanel<TEntity, TCard> _cardPanel = new();

    public SearchCardPanel(TFieldSearch field, TEntity[] data)
    {
        var context = new SearchEntity<TEntity, TFieldSearch>(field, data);
        context.OnSortEntity += ent => _cardPanel.Initialize(ent);

        _cardPanel.Initialize(data);

        Controls.Add(LayerPanel.LayoutPanel.CreateRow()
            .Column(75).ContentEnd(_cardPanel)
            .Column(25).ContentEnd(new SearchPanel.SearchPanel(context))
            .Build());
    }

    public SearchCardPanel<TEntity, TFieldSearch, TCard> SetContextMenu(IButtons<CardClickedToolStripArgs<TEntity>> buttons) => 
        this.With(_ => _cardPanel.SetContextMenu(buttons));

    public SearchCardPanel<TEntity, TFieldSearch, TCard> SetClickedPanel(IButton<CardClickedArgs<TEntity>> button) =>
        this.With(_ => _cardPanel.SetClickedCard(button));
}