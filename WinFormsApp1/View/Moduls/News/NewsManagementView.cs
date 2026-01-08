using Admin.ViewModel.News;
using DataAccess.Postgres.Models;
using WinFormsApp1.View;

namespace Admin.View.Moduls.News
{
    public class NewsManagementView : ManagementView<NewsEntity>
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

        public override ObjectCard<NewsEntity> CreateCard(NewsEntity entity)
            => new NewsCard(entity);
    }

}
