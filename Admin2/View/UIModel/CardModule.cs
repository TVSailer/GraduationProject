using Admin.Args;
using CSharpFunctionalExtensions;

namespace Admin.View.Moduls.UIModel;

public sealed class CardLayoutPanel<TEntity, TCard> : FlowLayoutPanel
    where TEntity : Entity, new()
    where TCard : ObjectCard<TEntity>, new()
{
    private IButtons<CardClickedArgs<TEntity>>? _menuStrip;

    public new event Action<object, CardClickedArgs<TEntity>>? OnClick;

    public CardLayoutPanel()
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Padding = new Padding(10);
    }

    private void Initialize(List<TEntity> entities)
    {
        entities
            .With(_ => Controls.Clear())?.ForEach(en =>
                Controls.Add(new TCard()
                    .Initialize(en)
                    .OnContextMenu(_menuStrip)
                    .OnClickedCard(OnClick)));
    }

    public CardLayoutPanel<TEntity, TCard> SetObjects(List<TEntity> entities) => this.With(_ => Initialize(entities));
    public CardLayoutPanel<TEntity, TCard> SetClickedCard(IButtons<CardClickedArgs<TEntity>> buttons) => this.With(_ => 
        buttons.GetButtons().ForEach(b => OnClick += (s, e) =>
        {
            b.OnClick(s, e);
            b.PerformClick();
        }));
    public CardLayoutPanel<TEntity, TCard> SetClickedCard(Action<object, CardClickedArgs<TEntity>>? action) => this.With(_ => OnClick += action);
    public CardLayoutPanel<TEntity, TCard> SetContextMenu(IButtons<CardClickedArgs<TEntity>> buttons) => this.With(_ => _menuStrip = buttons);
}