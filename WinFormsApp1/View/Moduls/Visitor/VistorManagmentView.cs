using Admin.ViewModel.Visitor;
using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Visitor
{
    public class VistorManagmentView : ManagementView<VisitorEntity>
    {
        private new readonly VisitorManagementModelView context;

        public VistorManagmentView(AdminMainView mainForm, VisitorManagementModelView modelView) : base(mainForm, modelView)
        {
            context = modelView;
            form.Text = "👥 Управление посетителями";
        }

        protected override Control LoadSerchPanel()
        {
            return new Panel();
        }

        public override ObjectCard<VisitorEntity> CreateCard(VisitorEntity entity)
            => new VisitorCard(entity);
    }
}
