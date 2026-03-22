using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;
using Visitor.View;
using Visitor.View.News;

namespace Visitor.DI.Module;

public class NewsManager;

public class NewsModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<NewsEntity>>().To<NewsRepository>().InSingletonScope();
        Kernel.Bind<UiView<NewsManager>>().To<NewsManagerPanelUi>();
    }
}