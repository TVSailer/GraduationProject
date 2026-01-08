using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;

namespace Admin.ViewModel.Visitor
{
    public class VisitorManagementModelView : ManagmentModelView<VisitorEntity>
    {
        public override ICommand OnLoadAddingView { get; set; }
        public override ICommand OnLoadDetailsView { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public VisitorManagementModelView(AdminMainView mainForm, VisitorsRepository visitorsRepository) : base(mainForm, visitorsRepository)
        {
        }
    }
}
