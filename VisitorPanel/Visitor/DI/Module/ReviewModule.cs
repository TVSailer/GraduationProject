using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;

namespace Visitor.DI.Module;

public class ReviewModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<ReviewEntity>>().To<ReviewRepository>().InSingletonScope();
    }
}