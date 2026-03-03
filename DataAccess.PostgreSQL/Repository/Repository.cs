using Microsoft.Extensions.Logging;

namespace DataAccess.Postgres.Repository
{
    public abstract class Repository<T>(ApplicationDbContext dbContext)
    {
        public readonly ApplicationDbContext DbContext = dbContext;

        public virtual T Add(T obj)
        {
            if (obj is null) throw new ArgumentNullException();

            var entity = DbContext.Add(obj);
            DbContext.SaveChanges();

            return (T)entity.Entity;
        }

        public abstract List<T> Get();
        public abstract void Update(long id, T entity);
        public abstract void Delete(long idEntity);

        public virtual T Add(T obj, out ILogger logger) { throw new MethodAccessException(); }
        public virtual bool TryDelete(long idEntity, out ILogger logger) { throw new MethodAccessException(); }
    }
}
