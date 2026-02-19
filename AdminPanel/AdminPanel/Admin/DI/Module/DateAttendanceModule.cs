using Admin.View.Moduls.DateAttendance;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Model.DateAttendance;
using Admin.ViewModel.Model.DateAttendance.Buttons;
using Admin.ViewModel.Model.Review;
using Admin.ViewModel.Model.Review.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;

namespace Admin.DI;

public record DateAttendanceManagment : IFieldData;

public class DateAttendanceModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<DateAttendanceEntity>>().To<DateAttendancesRepository>();

        Kernel.Bind<IView<DateAttendanceFieldData, DateAttendanceEntity>>().To<BaseUI<DateAttendanceFieldData, DateAttendanceEntity, DateAttendanceFieldDataButton>>();
        Kernel.Bind<IView<DateAttendanceManagment>>().To<DateAttendanceCardUi>();

        Kernel.Bind<DateAttendanceManagmentButton>().ToSelf();
        Kernel.Bind<DateAttendanceFieldDataButton>().ToSelf();
    }
}