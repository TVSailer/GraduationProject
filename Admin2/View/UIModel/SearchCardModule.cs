using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel;

public class SearchCardPanel<TEntity, TFieldSearch, TFieldData, TCard>
    where TFieldSearch : PropertyChange, IFieldData
    where TEntity : Entity, new()
    where TFieldData : IFieldData<TEntity>
    where TCard : ObjectCard<TEntity>, new()
{
    private readonly ControlView _control;
    private readonly SearchEntity<TEntity, TFieldSearch> _context;
    private readonly SearchPanel<TEntity, TFieldSearch> _searchPanel;
    private readonly CardLayoutPanel<TEntity, TCard> _cardPanel;

    public SearchCardPanel(
        ControlView control,
        SearchEntity<TEntity, TFieldSearch> context)
    {
        _control = control;
        _context = context;
    }

    public Control CreateControl()
    {
        return LayoutPanel.CreateRow()
            .Column(75).ContentEnd(new CardLayoutPanel<TEntity, TCard>()
                    .SetClickedCard((_, e) => _control.LoadView<TFieldData, TEntity>(e.Entity))
                    .SetObjects(_context.GetEntities()))
            .Column(25).ContentEnd(new SearchPanel<TEntity, TFieldSearch>(_context))
            .Build();
    }
}