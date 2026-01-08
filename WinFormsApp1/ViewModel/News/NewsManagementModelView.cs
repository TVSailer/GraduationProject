using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;

namespace Admin.ViewModel.News
{
    public class NewsManagementModelView : ManagmentModelView<NewsEntity>
    {
        private List<NewsEntity> newsEntities = new();

        public override ICommand OnLoadAddingView { get; set; }
        public override ICommand OnLoadDetailsView { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<NewsEntity> NewsEntities
        {
            get => newsEntities;
            private set
            {
                if (newsEntities.SequenceEqual(value))
                    return;

                newsEntities = value;
                OnPropertyChanged();
            }
        }

        public NewsManagementModelView(AdminMainView mainForm, NewsRepository newsRepository) : base(mainForm, newsRepository)
        {
        }
    }
}
