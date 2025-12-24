using Admin.View.Teachers;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;

namespace Admin.ViewModel.Teachers
{
    public class TeacherManagementModelView : AbstractManagmentModelView
    {
        private List<TeacherEntity> teacherEntities = new();

        public override ICommand OnBack { get; set; }
        public override ICommand OnLoadAddingView { get; set; }
        public override ICommand OnLoadDetailsView { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<TeacherEntity> TeacherEntities
        {
            get => teacherEntities;
            private set
            {
                if (teacherEntities.SequenceEqual(value))
                    return;

                teacherEntities = value;
                OnPropertyChanged();
            }
        }

        public TeacherManagementModelView(AdminMainView mainForm, TeacherRepository repository)
        {
            TeacherEntities = repository.Get();

            OnBack = new MainCommand(
            _ => mainForm.InitializeComponents());

            OnLoadAddingView = new MainCommand(
                _ =>
                {
                    using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                    {
                        scope.GetService<AddingTeacherView>().InitializeComponents();
                    }
                });

        }
    }
}
