using Admin.View.Lesson;
using Admin.ViewModel.News;
using WinFormsApp1.View;

namespace Admin.View.News
{
    public class NewsManagementView : AbstractManagementView
    {
        private new readonly NewsManagementModelView context;

        public NewsManagementView(AdminMainView mainForm, NewsManagementModelView viewModel) : base(mainForm, viewModel)
        {
            context = viewModel;
            form.Text = "📰 Управление новостями";
        }

        protected override Control LoadSerchPanel()
        {
            return new Panel();
        }

        protected override Control LoadCardsPanel()
        => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => context.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(context.NewsEntities))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        private void AddCard(FlowLayoutPanel p)
            => context.NewsEntities
            .ForEach(
                n =>
                {
                    p.Controls.Add(new NewsCard(n)
                    .With(c => c.OnCardClicked +=
                    (s, e) =>
                    {
                        //using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                        //    scope.GetService<EventDetailsView>(n.Id).InitializeComponents();
                    }));
                });
    }

}
