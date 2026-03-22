using Admin.FieldData.Model.Visitor;
using Admin.FieldData.Model.Visitor.Buttons;
using Admin.View;
using Admin.View.Moduls.Visitor;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI.Module;

public record VisitorNotBelongingLesson;
public record VisitorBelongingLesson;
public record VisitorManager;

public class VisitorModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<VisitorsRepository, Repository<VisitorEntity>>().To<VisitorsRepository>().InSingletonScope();

        Kernel.Bind<UiView<VisitorFieldData>>().To<VisitorAddingPanelUi>();
        Kernel.Bind<UiView<VisitorFieldData, VisitorEntity>>().To<VisitorDetailsPanelUi>();
        Kernel.Bind<UiView<VisitorNotBelongingLesson>>().To<VisitorNotBelongingLessonCardUi>();
        Kernel.Bind<UiView<VisitorBelongingLesson>>().To<VisitorBelongingLessonCardUi>();
        Kernel.Bind<UiView<VisitorManager>>().To<ManagerEntityUi<
            VisitorManager, 
            VisitorEntity, 
            VisitorFieldSearch, 
            VisitorCard,
            VisitorManagerClicked>>();
    }
}