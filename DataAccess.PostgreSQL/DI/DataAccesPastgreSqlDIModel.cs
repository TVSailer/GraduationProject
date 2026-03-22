using DataAccess.PostgreSQL.Repository;
using Domain.Entitys;
using Domain.Repository;
using Ninject.Modules;

namespace DataAccess.PostgreSQL.DI;

public class DataAccesPastgreSqlDIModel : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IRepository<EventEntity>>().To<EventRepositoryModel>().InSingletonScope();
        Kernel.Bind<IRepository<CategoryEntity>>().To<RepositoryModel<CategoryEntity>>().InSingletonScope();
        //Kernel.Bind<IRepository<NewsModel>>().To<NewsRepositoryModel>().InSingletonScope();
    }
}