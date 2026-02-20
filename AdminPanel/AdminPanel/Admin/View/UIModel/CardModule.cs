using Admin.Args;
using CSharpFunctionalExtensions;
using Logica.Interface;

namespace Admin.View.Moduls.UIModel;

public sealed class CardLayoutPanel<TEntity, TCard> : FlowLayoutPanel
    where TEntity : Entity, new()
    where TCard : ObjectCard<TEntity>, new()
{
    private IButtons<CardClickedToolStripArgs<TEntity>>? _menuStrip;
    private IButton<CardClickedArgs<TEntity>>? _onClick;

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
                    .OnClickedCard(_onClick)));
    }

    public CardLayoutPanel<TEntity, TCard> SetObjects(List<TEntity> entities) => this.With(_ => Initialize(entities));
    public CardLayoutPanel<TEntity, TCard> SetClickedCard(IButton<CardClickedArgs<TEntity>> buttons) => this.With(_ => _onClick =buttons);
    public CardLayoutPanel<TEntity, TCard> SetContextMenu(IButtons<CardClickedToolStripArgs<TEntity>> buttons) => this.With(_ => _menuStrip = buttons);
}