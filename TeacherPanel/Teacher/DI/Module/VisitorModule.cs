using Ninject.Modules;
using Teacher.View.Visitor;
using Teacher.ViewModel.Visitor;
using UserInterface.View.Base;

namespace Teacher.DI.Module;

public class VisitorModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<VisitorAddingPanelViewModel>>().To<VisitorAddingPanelView>();
        Kernel.Bind<IView<VisitorBelongingLessonPanelViewModel>>().To<VisitorBelongingLessonPanelView>();
        Kernel.Bind<IView<VisitorNotBelongingLessonPanelViewModel>>().To<VisitorNotBelongingLessonPanelView>();
        Kernel.Bind<IView<VisitorDetailsPanelViewModel>>().To<VisitorDetailsPanelView>();
    }
}