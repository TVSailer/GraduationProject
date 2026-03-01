using Admin.FieldData.Model.DateAttendance;
using Admin.View.Moduls.DateAttendance;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI.Module;

public record DateAttendanceManager;

public class DateAttendanceModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<DateAttendanceEntity>>().To<DateAttendancesRepository>();

        //Kernel.Bind<UiView<DateAttendanceFieldData, DateAttendanceEntity>>().To<>();
        Kernel.Bind<UiView<DateAttendanceManager>>().To<DateAttendancePanelUi>();
    }
}