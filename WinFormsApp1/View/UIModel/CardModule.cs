using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;
using System.Windows.Forms;

namespace Admin.View.Moduls.UIModel;

public class CardModule<TEntity>(ObjectCard<TEntity> card) : ICardModule<TEntity>
    where TEntity : Entity, new()
{
    private readonly FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
        .With(p => p.Dock = DockStyle.Fill)
        .With(p => p.AutoScroll = true)
        .With(p => p.Padding = new Padding(10));
    public Action<TEntity>? OnClick { get; set; }

    public Control CreateControl() => flowLayoutPanel;

    public CardModule<TEntity> UpdateCard(List<TEntity> entities)
    {
        entities
            .With(_ => flowLayoutPanel.Controls.Clear())
            .ForEach(en =>
                flowLayoutPanel.Controls.Add(card.CreateCard(en)
                    .With(c => c.OnCardClicked += (s, e) =>
                        OnClick?.Invoke(en))));

        return this;
    }
}