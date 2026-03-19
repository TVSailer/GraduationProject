using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;
using Visitor.FieldData.Lesson;
using Visitor.FieldData.Lesson.Button;
using Visitor.View;
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
        Kernel.Bind<UiView<LessonManager>>().To<ManagerPanelUi<LessonManager, LessonEntity, LessonCard, LessonManagerButtons>>();
    }
}