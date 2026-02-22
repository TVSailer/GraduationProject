using CSharpFunctionalExtensions;
using DataAccess.Postgres.Extensions;

namespace DataAccess.Postgres.Repository
{
    public abstract class Repository<T>(ApplicationDbContext dbContext)
        where T : Entity
    {
        public readonly ApplicationDbContext DbContext = dbContext;

        public virtual void Add(T obj)
        {
            if (obj is null) throw new ArgumentNullException();

            DbContext.Add(entity: obj.Entity());
            DbContext.SaveChanges();
        }

        public abstract List<T> Get();
        public abstract void Update(long id, T entity);
        public abstract void Delete(long idEntity);

    }
}
