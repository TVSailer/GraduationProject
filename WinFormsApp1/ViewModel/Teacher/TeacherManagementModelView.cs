using Admin.View.Moduls.Teacher;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;

namespace Admin.ViewModel.Teachers
{
    public class TeacherManagementModelView : ManagmentModelView<TeacherEntity>
    {
        public override ICommand OnLoadAddingView { get; set; }
        public override ICommand OnLoadDetailsView { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TeacherManagementModelView(AdminMainView mainForm, TeacherRepository repository) : base(mainForm, repository)
        {
            OnLoadAddingView = new MainCommand(
                _ =>
                {
                    using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                    {
                        scope.GetService<TeacherAddingView>().InitializeComponents();
                    }
                });

        }
    }
}
