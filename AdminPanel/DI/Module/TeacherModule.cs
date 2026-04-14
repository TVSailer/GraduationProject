using Admin.View.Teacher;
using Admin.ViewModel.Teacher;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class TeacherModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<TeacherManagerPanelViewModel>>().To<TeacherManagerPanelView>();
        Kernel.Bind<IView<TeacherAddingPanelViewModel>>().To<TeacherAddingPanelView>();
        Kernel.Bind<IView<TeacherDetailsPanelViewModel>>().To<TeacherDetailsPanelView>();
    }
}