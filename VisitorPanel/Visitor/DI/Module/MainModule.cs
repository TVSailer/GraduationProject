using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;
using Visitor.View.Main;

namespace Visitor.DI.Module;

public class MainModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<MementoVisitor>().ToSelf().InSingletonScope();
        Kernel.Bind<UiView<MainFieldData>>().To<MainUi>();
        Kernel.Bind<Repository<CategoryEntity>>().To<CategoryRepository>();
    }
}

public class MainFieldData;
