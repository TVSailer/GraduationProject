using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;

namespace Admin.View.Moduls.UIModel
{
    public class CardModule<TEntity, TCard>(ManagmentModelView<TEntity> managment)
        : IUIModel
        where TEntity : Entity, new()
        where TCard : ObjectCard<TEntity>, new()
    {
        public Control CreateControl()
            => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => managment.SerchManagment.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(managment.SerchManagment.DataEntitys))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        private void AddCard(FlowLayoutPanel p)
            => managment.SerchManagment.DataEntitys
            .ForEach(
                en =>
                {
                    p.Controls.Add(new TCard().Initialize(en)
                    .With(c => c.OnCardClicked +=
                    (s, e) => {
                        if (en is TEntity entity)
                            managment.OnLoadDetailsView.Execute(en);
                        else throw new ArgumentException();
                    }));
                });
    }
}
