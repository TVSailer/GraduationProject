using DataAccess.PostgreSQL.Repository;
using Domain.Entitys;
using Domain.Repository;
using Ninject.Modules;

namespace DataAccess.PostgreSQL.DI;

public class DataAccesPostgreSqlModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IRepository<EventEntity>>().To<EventRepository>().InSingletonScope();
        Kernel.Bind<IRepository<CategoryEntity>>().To<RepositoryModel<CategoryEntity>>().InSingletonScope();
        Kernel.Bind<IRepository<AuthEntity>>().To<RepositoryModel<AuthEntity>>().InSingletonScope();
        Kernel.Bind<IRepository<NewsEntity>>().To<NewsRepository>().InSingletonScope();
        Kernel.Bind<IRepository<TeacherEntity>>().To<TeacherRepository>().InSingletonScope();
        Kernel.Bind<IRepository<VisitorEntity>>().To<VisitorRepository>().InSingletonScope();
        Kernel.Bind<IRepository<LessonEntity>>().To<LessonRepository>().InSingletonScope();
        Kernel.Bind<IRepository<ReviewEntity>>().To<RepositoryModel<ReviewEntity>>().InSingletonScope();
        Kernel.Bind<IRepository<DateAttendanceEntity>>().To<RepositoryModel<DateAttendanceEntity>>().InSingletonScope();
    }
}