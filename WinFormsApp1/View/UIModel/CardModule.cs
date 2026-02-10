using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel
{
    public class CardModule<TEntity, TFieldSearch, TFieldData>(SearchEntity<TEntity, TFieldSearch> searchEntity, ObjectCard<TEntity> card, ControlView control) : ICardModule<TEntity>
        where TEntity : Entity, new()
        where TFieldSearch : PropertyChange, IFieldData
        where TFieldData : IFieldData<TEntity>
    {
        public Control CreateControl()
            => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => searchEntity.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(searchEntity.DataEntitys))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        private void AddCard(FlowLayoutPanel p)
            => searchEntity.DataEntitys
            .ForEach(
                en =>
                {
                    p.Controls.Add(card.CreateCard(en)
                    .With(c => c.OnCardClicked +=
                    (s, e) => {
                        if (en is TEntity entity)
                            control.LoadView<TFieldData, TEntity>(entity);
                        else throw new ArgumentException();
                    }));
                });
    }
}
