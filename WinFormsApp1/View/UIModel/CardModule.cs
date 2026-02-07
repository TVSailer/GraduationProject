using Admin.Commands_Handlers.Managment;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;
using MediatR;

namespace Admin.View.Moduls.UIModel
{
    public class CardModule<TEntity, TField>(IMediator mediator, SearchEntity<TEntity, TField> searchEntity, ObjectCard<TEntity> card) : IUIModel
        where TEntity : Entity, new()
        where TField : PropertyChange
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
                        {
                            mediator.Send(new SendEntityRequest<TEntity>(entity));
                        }
                        else throw new ArgumentException();
                    }));
                });
    }
}
