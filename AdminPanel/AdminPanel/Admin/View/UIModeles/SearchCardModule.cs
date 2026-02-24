using Admin.Args;
using Admin.View.UIModel;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.Interface;
using Logica.Message;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel;

public class SearchCardPanel<TEntity, TFieldSearch, TCard>
    where TFieldSearch : PropertyChange, IFieldData
    where TEntity : Entity, new()
    where TCard : ObjectCard<TEntity>, new()
{
    private readonly SearchEntity<TEntity, TFieldSearch> _context;
    private readonly CardLayoutPanel<TEntity, TCard> _cardPanel = new();

    public SearchCardPanel(SearchEntity<TEntity, TFieldSearch> context)
    {
        _context = context;
        _context.OnSortEntity = ent => _cardPanel.SetObjects(ent);
    }

    public SearchCardPanel<TEntity, TFieldSearch, TCard> SetContextMenu(IButtons<CardClickedToolStripArgs<TEntity>> buttons) => 
        this.With(_ => _cardPanel.SetContextMenu(buttons));

    public SearchCardPanel<TEntity, TFieldSearch, TCard> SetClickedPanel(IButton<CardClickedArgs<TEntity>> button) =>
        this.With(_ => _cardPanel.SetClickedCard(button));

    public Control CreateControl()
    {
        return LayoutPanel.CreateRow()
            .Column(75).ContentEnd(_cardPanel.SetObjects(_context.GetData()))
            .Column(25).ContentEnd(new SearchPanel<TEntity, TFieldSearch>(_context))
            .Build();
    }
}