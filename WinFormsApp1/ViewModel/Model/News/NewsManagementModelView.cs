using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;

namespace Admin.ViewModels.News
{
    public class NewsManagementModelView
    {
        private List<NewsEntity> newsEntities = new();

        //public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public NewsManagementModelView(AdminMainView mainForm, NewsRepository newsRepository)
        {
        }
    }
}
