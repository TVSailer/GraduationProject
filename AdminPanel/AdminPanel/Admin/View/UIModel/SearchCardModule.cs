using Admin.Args;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel;

public class SearchCardButton<T, TFieldData>(ControlView controlView) : IButtons<CardClickedArgs<T>>
    where T : Entity, new()
    where TFieldData : IFieldData<T>
{
    public List<CustomButton> GetButtons(object? data, CardClickedArgs<T> eventArgs)
        => [
            new CustomButton()
                .CommandClick(() => controlView.LoadView<TFieldData, T>(eventArgs.Entity))
        ];
}

public class SearchCardPanel<TEntity, TFieldSearch, TFieldData, TCard>
    where TFieldSearch : PropertyChange, IFieldData
    where TEntity : Entity, new()
    where TFieldData : IFieldData<TEntity>
    where TCard : ObjectCard<TEntity>, new()
{
    private readonly ControlView _control;
    private readonly SearchEntity<TEntity, TFieldSearch> _context;
    private readonly CardLayoutPanel<TEntity, TCard> _cardPanel = new ();

    public SearchCardPanel(
        ControlView control,
        SearchEntity<TEntity, TFieldSearch> context)
    {
        _control = control;
        _context = context;
    }

    public SearchCardPanel<TEntity, TFieldSearch, TFieldData, TCard> SetContextMenu(IButtons<CardClickedArgs<TEntity>> buttons) => this.With(_ => _cardPanel.SetContextMenu(buttons));

    public Control CreateControl()
    {
        return LayoutPanel.CreateRow()
            .Column(75).ContentEnd(_cardPanel
                    .SetClickedCard(new SearchCardButton<TEntity,TFieldData>(_control))
                    .SetObjects(_context.GetEntities()))
            .Column(25).ContentEnd(new SearchPanel<TEntity, TFieldSearch>(_context))
            .Build();
    }
}