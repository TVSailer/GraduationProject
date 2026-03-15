using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;
using Visitor.View;

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