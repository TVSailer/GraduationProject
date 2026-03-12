using Admin.FieldData.Model.Lesson.Buttons;
using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.ViewModel.Model.Lesson;
using Admin.ViewModel.Model.Lesson.Buttons;
using Admin.ViewModels.Lesson;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI.Module;

public record LessonManager;

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>().InSingletonScope();
        Kernel.Bind<MementoLesson>().ToSelf().InSingletonScope();

        Kernel.Bind<UiView<LessonFieldData>>().To<LessonPanelUi<LessonAddingButton>>();
        Kernel.Bind<UiView<LessonFieldData, LessonEntity>>().To<LessonPanelUi<LessonDetailsButton>>();
        Kernel.Bind<UiView<LessonManager>>().To<ManagerEntityUi<
            LessonManager, 
            LessonEntity, 
            LessonFieldSearch, 
            LessonCard, 
            LessonManagerClicked>>();
    }
}
