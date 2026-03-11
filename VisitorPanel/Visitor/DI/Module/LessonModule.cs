using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;
using Visitor.FieldData.Lesson;
using Visitor.View.Lesson;

namespace Visitor.DI.Module;

public record LessonManager;

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>().InSingletonScope();
        Kernel.Bind<MementoLesson>().ToSelf().InSingletonScope();

        Kernel.Bind<UiView<LessonDataUi, LessonEntity>>().To<LessonPanelUi>();
        Kernel.Bind<UiView<LessonManager>>().To<ManagerLessonPanelUi>();
    }
}
