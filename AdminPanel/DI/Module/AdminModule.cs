using Admin.View.Moduls.AdminMain;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI.Module;

public record AdminFieldData;

public class AdminModule : NinjectModule
{
    public override void Load()
    {

        Kernel.Bind<UiView<AdminFieldData>>().To<AdminMainUi>();
        Kernel.Bind<Repository<CategoryEntity>>().To<CategoryRepository>();
    }
}