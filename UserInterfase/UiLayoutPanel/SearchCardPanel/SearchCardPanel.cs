using System.Windows.Forms;
using Extension_Func_Library;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.SearchCardPanel;

public class SearchCardPanel<TEntity, TFieldSearch, TCard> : Panel
    where TFieldSearch : SearchFieldData<TEntity>
    where TEntity : new()
    where TCard : ObjectCard<TEntity>, new()
{
    private readonly TFieldSearch _field;
    private readonly CardLayoutPanel<TEntity, TCard> _cardPanel = new();

    public SearchCardPanel(TFieldSearch field)
    {
        _field = field;
        Dock = DockStyle.Fill;
    }

    public SearchCardPanel<TEntity, TFieldSearch, TCard> SetContextMenu(IButtons<CardClickedToolStripArgs<TEntity>> buttons)
    {
        _cardPanel.SetContextMenu(buttons);
        return this;
    }

    public SearchCardPanel<TEntity, TFieldSearch, TCard> SetClickedPanel(IButton<CardClickedArgs<TEntity>> button)
    {
        _cardPanel.SetClickedCard(button);
        return this;
    }

    public SearchCardPanel<TEntity, TFieldSearch, TCard> Initialize(TEntity[] data)
    {
        _cardPanel.Initialize(data);

        var context = new SearchEntity<TEntity, TFieldSearch>(_field, data);
        context.OnSortEntity += ent => _cardPanel.Initialize(ent);

        Controls.Add(new BuilderLayoutPanel().Row()
            .Column(75).ContentEnd(_cardPanel)
            .Column(25).ContentEnd(new SearchPanel.SearchPanel(context))
            .Build());

        return this;
    }
}