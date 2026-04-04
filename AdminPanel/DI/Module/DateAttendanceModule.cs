using Admin.View.Moduls.DateAttendance;
using Admin.ViewModel.Model.DateAttendance;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class DateAttendanceModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<DateAttendanceManagerPanelViewModel>>().To<DateAttendanceManagerPanelView>();
        Kernel.Bind<IForma<DateAttendanceAddingPanelViewModel>>().To<DateAttendanceAddingPanelView>();
    }
}