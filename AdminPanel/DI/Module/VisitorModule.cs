using Admin.View.Visitor;
using Admin.ViewModel.Visitor;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class VisitorModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<VisitorAddingPanelViewModel>>().To<VisitorAddingPanelView>();
        Kernel.Bind<IView<VisitorBelongingLessonPanelViewModel>>().To<VisitorBelongingLessonPanelView>();
        Kernel.Bind<IView<VisitorNotBelongingLessonPanelViewModel>>().To<VisitorNotBelongingLessonPanelView>();
        Kernel.Bind<IView<VisitorDetailsPanelViewModel>>().To<VisitorDetailsPanelView>();
        Kernel.Bind<IView<VisitorManagerPanelViewModel>>().To<VisitorManagerPanelView>();
    }
}