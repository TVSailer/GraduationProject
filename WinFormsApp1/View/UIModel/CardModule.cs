using Admin.Commands_Handlers.Managment;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Lesson;
using Admin.ViewModel.Managment;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using MediatR;

namespace Admin.View.Moduls.UIModel
{
    public class CardModule<TEntity, TCard>(IMediator mediator, SerchManagment<TEntity> serchManagment)
        : IUIModel
        where TEntity : Entity, new()
        where TCard : ObjectCard<TEntity>, new()
    {
        public Control CreateControl()
            => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => serchManagment.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(serchManagment.DataEntitys))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        private void AddCard(FlowLayoutPanel p)
            => serchManagment.DataEntitys
            .ForEach(
                en =>
                {
                    p.Controls.Add(new TCard().Initialize(en)
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
