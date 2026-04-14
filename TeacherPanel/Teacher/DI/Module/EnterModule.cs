using Ninject.Modules;
using Teacher.View.Enter;
using Teacher.View.Teacher;
using Teacher.ViewModel.Enter;
using Teacher.ViewModel.Teacher;
using UserInterface.View.Base;

namespace Teacher.DI.Module;

public class EnterModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<TeacherProfelPanelViewModel>>().To<TeacherProfelPanelView>();
        Kernel.Bind<IForma<EnterPanelViewModel>>().To<EnterPanelView>();
    }
}