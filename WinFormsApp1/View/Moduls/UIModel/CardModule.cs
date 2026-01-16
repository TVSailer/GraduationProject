using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using WinFormsApp1.View;

namespace Admin.View.Moduls.UIModel
{
    public class CardModule<TEntity, TCard> : IUIModel
        where TEntity : Entity, new()
        where TCard : ObjectCard<TEntity>, new()
    {
        private readonly SerchManagment<TEntity> context;
        private readonly Action<TEntity> setEntity;

        public CardModule(SerchManagment<TEntity> serchManagment, Action<TEntity> entity)
        {
            context = serchManagment;
            setEntity = entity;
        }

        public Control CreateControl()
            => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => context.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(context.DataEntitys))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        private void AddCard(FlowLayoutPanel p)
            => context.DataEntitys
            .ForEach(
                en =>
                {
                    p.Controls.Add(new TCard().Initialize(en)
                    .With(c => c.OnCardClicked +=
                    (s, e) => {
                        if (en is TEntity entity)
                            setEntity(en);
                        else throw new ArgumentException();
                    }));
                });
    }
}
