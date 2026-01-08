using Admin.View.Moduls.Event;
using Admin.View.Moduls.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;

namespace Admin.ViewModel.Lesson
{
    public class LessonManagmentViewModel : ManagmentModelView<LessonEntity>
    {
        public override ICommand OnLoadAddingView { get; set; }
        public override ICommand OnLoadDetailsView { get; set; }
        public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public LessonManagmentViewModel(AdminMainView mainForm, LessonsRepository lessonsRepository) : base(mainForm, lessonsRepository)
        {
            OnLoadAddingView = new MainCommand(
                _ =>
                {
                    using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                    {
                        scope.GetService<LessonAddingViewModel>();
                        scope.GetService<LessonAddingView>().InitializeComponents();
                    }
                });

            OnLoadDetailsView = new MainCommand(
               obj =>
               {
                   if (obj is LessonEntity les)
                       using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                       {
                           scope.GetService<LessonDetailsViewModel>().Initialize(les);
                           scope.GetService<LessonDetailsView>().InitializeComponents();
                       }
               });
        }
    }
}
