using Ninject.Modules;
using UserInterface.View.Base;
using Visitor.View.Lesson;
using Visitor.ViewModel.Lesson;

namespace Visitor.DI.Module;

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<LessonPanelViewModel>>().To<LessonPanelView>();
        Kernel.Bind<IView<LessonManagerPanelViewModel>>().To<LessonManagerPanelView>();
    }
}