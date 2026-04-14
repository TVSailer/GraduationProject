using Ninject.Modules;
using Teacher.View.Lesson;
using Teacher.ViewModel.Lesson;
using UserInterface.View.Base;

namespace Teacher.DI.Module;

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<LessonPanelViewModel>>().To<LessonPanelView>();
        Kernel.Bind<IView<LessonManagerPanelViewModel>>().To<LessonManagerPanelView>();
    }
}