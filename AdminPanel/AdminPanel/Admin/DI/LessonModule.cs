using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.View.Moduls.Review;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Lesson.Buttons;
using Admin.ViewModel.Model.Review;
using Admin.ViewModel.Model.Review.Buttons;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;

namespace Admin.DI;

public record LessonManagment : IFieldData;
public record LessonReviewManagment : IFieldData;

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
        Kernel.Bind<IParametersSearch<ReviewEntity, ReviewFieldSearch>>().To<ReviewSearch>();

        Kernel.Bind<IView<LessonAddingFieldData>, 
            IView<LessonAddingFieldData, LessonEntity>>().To<BaseUI<LessonAddingFieldData, LessonEntity, LessonAddingButton>>();
        Kernel.Bind<IView<LessonDetailsFieldData>, 
            IView<LessonDetailsFieldData, LessonEntity>>().To<BaseUI<LessonDetailsFieldData, LessonEntity, LessonDetailsButton>>();
        Kernel.Bind<IView<LessonManagment>>().To<ManagmentEntityUi<
            LessonManagment, 
            LessonEntity, 
            LessonFieldSearch, 
            LessonCard, 
            LessonManagmentButton>>();
        Kernel.Bind<IView<LessonReviewManagment>>().To<LessonReviewCardUi>();

        Kernel.Bind<LessonManagmentButton>().ToSelf();
        Kernel.Bind<LessonAddingButton>().ToSelf();
        Kernel.Bind<LessonDetailsButton>().ToSelf();
        Kernel.Bind<ReviewLessonDetailsButton>().ToSelf();
    }
}