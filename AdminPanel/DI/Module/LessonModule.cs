using Admin.View.Lesson;
using Admin.View.Lesson.Schedule;
using Admin.ViewModel.Lesson;
using Admin.ViewModel.Lesson.Schedule;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<LessonAddingPanelViewModel>>().To<LessonAddingPanelView>();
        Kernel.Bind<IView<LessonDetailsPanelViewModel>>().To<LessonDetailsPanelView>();
        Kernel.Bind<IView<LessonManagerPanelViewModel>>().To<LessonManagerPanelView>();
        Kernel.Bind<IForma<ScheduleViewModel>>().To<ScheduleView>();
    }
}
