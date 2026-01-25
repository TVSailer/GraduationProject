using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Lesson;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Microsoft.Win32;
using Ninject.Modules;

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>();
        Kernel.Bind<Repository<LessonCategoryEntity>>().To<LessonCategoryRepositroy>();

        Kernel.Bind<IViewModele<LessonEntity>>().To<LessonAddingPanel>();
        Kernel.Bind<IViewModele<LessonEntity>>().To<LessonDetailsPanel>();

        Kernel.Bind<IView<LessonEntity>>().To<UIEntity<LessonEntity, LessonDetailsPanel>>();
        Kernel.Bind<IView<LessonEntity>>().To<UIEntity<LessonEntity, LessonAddingPanel>>();

        Kernel.Bind<ManagmentModelView<LessonEntity>>().ToSelf();
        Kernel.Bind<ManagementView<LessonEntity, LessonCard>>().ToSelf();
        Kernel.Bind<SerchManagment<LessonEntity>>().To<LessonSerch>();
    }
}