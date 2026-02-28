using Admin.View.Moduls.AdminMain;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI;

public record AdminFieldData;

public class AdminModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<UiView<AdminFieldData>>().To<AdminMainUi>();
        Kernel.Bind<Repository<CategoryEntity>>().To<CategoryRepository>();
        Kernel.Bind<Repository<TeacherEntity>>().To<TeacherRepository>();
    }
}