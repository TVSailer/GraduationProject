using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;
using WinFormsApp1.ViewModel.Model.Teacher;

public class TeacherModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<TeacherEntity>>().To<TeacherRepository>();

        Kernel.Bind<IViewModele<TeacherEntity>>().To<TeacherAddingPanel>();
        Kernel.Bind<IViewModele<TeacherEntity>>().To<TeacherDetailsPanel>();

        Kernel.Bind<IView<TeacherEntity>>().To<UIEntity<TeacherEntity, TeacherAddingPanel>>();
        Kernel.Bind<IView<TeacherEntity>>().To<UIEntity<TeacherEntity, TeacherDetailsPanel>>();

        Kernel.Bind<ManagmentModelView<TeacherEntity>>().ToSelf();
        Kernel.Bind<ManagementView<TeacherEntity, TeacherCard>>().ToSelf();
        Kernel.Bind<SerchManagment<TeacherEntity>>().To<TeacherSerch>();

    }
}