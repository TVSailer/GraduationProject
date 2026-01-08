using Admin.View;
using Admin.ViewModel.Teachers;
using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Teacher
{
    public partial class TeacherManagementView : ManagementView<TeacherEntity>
    {
        private readonly TeacherManagementModelView context;

        public TeacherManagementView(AdminMainView mainForm, TeacherManagementModelView modelView) : base(mainForm, modelView)
        {
            context = modelView;

            form.Text = "👨‍🏫 Управление преподавателями";
        }

        protected override Control LoadSerchPanel()
        {
            return new Panel();
        }

        public override ObjectCard<TeacherEntity> CreateCard(TeacherEntity entity)
            => new TeacherCard(entity);
    }
}
