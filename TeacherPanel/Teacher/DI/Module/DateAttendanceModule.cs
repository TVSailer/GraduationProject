using Ninject.Modules;
using Teacher.View.DateAttendance;
using Teacher.ViewModel.DateAttendance;
using UserInterface.View.Base;

namespace Teacher.DI.Module;

public class DateAttendanceModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<DateAttendanceManagerPanelViewModel>>().To<DateAttendanceManagerPanelView>();
        Kernel.Bind<IForma<DateAttendanceAddingPanelViewModel>>().To<DateAttendanceAddingPanelView>();
        Kernel.Bind<IForma<DateAttendanceUdpatePanelViewModel>>().To<DateAttendanceUpdatePanelView>();
    }
}