using Admin.Commands_Handlers.Managment;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;
using MediatR;

namespace Admin.View.Moduls.UIModel
{
    public class CardModule<TEntity>(IMediator mediator, SerchEntity<TEntity> serchEntity, ObjectCard<TEntity> card) : IUIModel
        where TEntity : Entity, new()
    {
        public Control CreateControl()
            => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => serchEntity.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(serchEntity.DataEntitys))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        private void AddCard(FlowLayoutPanel p)
            => serchEntity.DataEntitys
            .ForEach(
                en =>
                {
                    p.Controls.Add(card.CreateCard(en)
                    .With(c => c.OnCardClicked +=
                    (s, e) => {
                        if (en is TEntity entity)
                        {
                            mediator.Send(new SendEntity<TEntity>(entity));
                        }
                        else throw new ArgumentException();
                    }));
                });
    }
}
