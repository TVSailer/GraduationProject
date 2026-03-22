using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;
using Visitor.FieldData.Visitor;
using Visitor.View.Main;
using Visitor.View.Visitor;

namespace Visitor.DI.Module;

public class MainModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<MementoVisitor>().ToSelf().InSingletonScope();
        Kernel.Bind<UiView<MainFieldData>>().To<MainUi>();
        Kernel.Bind<UiView<MementoVisitor>>().To<VisitorPanelUi>();
        Kernel.Bind<Repository<CategoryEntity>>().To<CategoryRepository>();
    }
}

public class MainFieldData;
