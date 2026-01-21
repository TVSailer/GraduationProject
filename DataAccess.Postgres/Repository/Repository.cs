namespace DataAccess.Postgres.Repository
{
    public abstract class Repository<T>
    {
        public readonly ApplicationDbContext DbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual void Add(object obj)
        {
            if (obj is null) throw new ArgumentNullException();

            DbContext.Add(obj);
            DbContext.SaveChanges();
        }

        public abstract List<T> Get();
        public abstract void Update(long id, T entity);
        public abstract void Delete(T entity);
    }
}
