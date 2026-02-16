using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;

public record LessonMangment : IFieldData;
public record VisitorBelongingLesson : IFieldData;

public class LessonAddingFieldData(TeacherRepository teacherRepository, LessonCategoryRepositroy eventCategoryRepositroy)
    : LessonFieldData(teacherRepository, eventCategoryRepositroy);

public class LessonDetailsFieldData(TeacherRepository teacherRepository, LessonCategoryRepositroy eventCategoryRepositroy)
    : LessonFieldData(teacherRepository, eventCategoryRepositroy);


public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>().InSingletonScope();
        Kernel.Bind<Repository<LessonCategoryEntity>>().To<LessonCategoryRepositroy>().InSingletonScope();
        Kernel.Bind<VisitorsLessonRepository>().ToSelf().InSingletonScope();

        Kernel.Bind<IParametersSearch<LessonEntity, LessonFieldSearch>>().To<LessonSearch>();

        Kernel.Bind<
            IView<LessonAddingFieldData>, 
            IView<LessonAddingFieldData, LessonEntity>>().To<
            BaseUI<LessonAddingFieldData, LessonEntity, LessonAddingButton>>();
        Kernel.Bind<
            IView<LessonDetailsFieldData>, 
            IView<LessonDetailsFieldData, LessonEntity>>().To<
            BaseUI<LessonDetailsFieldData, LessonEntity, LessonDetailsButton>>();
        Kernel.Bind<IView<LessonMangment>>().To<ManagmentEntityUi<
            LessonMangment, 
            LessonEntity, 
            LessonFieldSearch, 
            LessonDetailsFieldData, 
            LessonCard, 
            BaseManagmentButton<LessonMangment, LessonEntity, LessonAddingFieldData>>>();
        

        Kernel.Bind<BaseManagmentButton<LessonMangment, LessonEntity, LessonAddingFieldData>>().ToSelf();
        Kernel.Bind<LessonAddingButton>().ToSelf();
        Kernel.Bind<LessonDetailsButton>().ToSelf();
        
    }
}
