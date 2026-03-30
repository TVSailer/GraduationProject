using Admin.View.Moduls.Lesson;
using Admin.View.Moduls.Lesson.Schedule;
using Admin.ViewModel.Model.Lesson;
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
