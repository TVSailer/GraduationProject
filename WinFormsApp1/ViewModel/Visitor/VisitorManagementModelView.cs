using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;

namespace Admin.ViewModel.Visitor
{
    public class VisitorManagementModelView : AbstractManagmentModelView
    {
        private List<VisitorEntity> visitorEntities = new();

        public override ICommand OnBack { get; set; }
        public override ICommand OnLoadAddingView { get; set; }
        public override ICommand OnLoadDetailsView { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<VisitorEntity> VisitorEntities
        {
            get => visitorEntities;
            private set
            {
                if (visitorEntities.SequenceEqual(value))
                    return;

                visitorEntities = value;
                OnPropertyChanged();
            }
        }

        public VisitorManagementModelView(AdminMainView mainForm, VisitorsRepository visitorsRepository)
        {
            VisitorEntities = visitorsRepository.Get();

            OnBack = new MainCommand(
                _ => mainForm.InitializeComponents());
        }
    }
}
