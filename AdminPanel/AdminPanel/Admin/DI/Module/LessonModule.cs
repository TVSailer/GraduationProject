using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Model.Lesson;
using Admin.ViewModel.Model.Lesson.Buttons;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;
using User_Interface_Library.View;

namespace Admin.DI.Module;

public record LessonManagment : IFieldData;

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>().InSingletonScope();
        Kernel.Bind<Repository<DateAttendanceEntity>>().To<DateAttendancesRepository>().InSingletonScope();
        Kernel.Bind<MementoLesson>().ToSelf().InSingletonScope();

        Kernel.Bind<UiView<LessonFieldData>>().To<LessonPanelUi<LessonAddingButton>>();
        Kernel.Bind<UiView<LessonFieldData, LessonEntity>>().To<LessonPanelUi<LessonDetailsButton>>();
        Kernel.Bind<UiView<LessonManagment>>().To<ManagmentEntityUi<
            LessonManagment, 
            LessonEntity, 
            LessonFieldSearch, 
            LessonCard, 
            LessonManagmentButton>>();
    }
}
