using Admin.View.DateAttendance;
using Admin.ViewModel.DateAttendance;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class DateAttendanceModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<DateAttendanceManagerPanelViewModel>>().To<DateAttendanceManagerPanelView>();
        Kernel.Bind<IForma<DateAttendanceAddingPanelViewModel>>().To<DateAttendanceAddingPanelView>();
        Kernel.Bind<IForma<DateAttendanceUdpatePanelViewModel>>().To<DateAttendanceUpdatePanelView>();
    }
}