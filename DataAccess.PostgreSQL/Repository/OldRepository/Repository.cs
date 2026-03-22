using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.Logger;
using Microsoft.Extensions.Logging;
using ILogger = DataAccess.PostgreSQL.Logger.ILogger;

namespace DataAccess.PostgreSQL.Repository
{
    public abstract class Repository<T>(ApplicationDbContext dbContext)
        where T : Entity 
    {
        public readonly ApplicationDbContext DbContext = dbContext;

        public virtual T Add(T obj)
        {
            if (obj is null) throw new ArgumentNullException();

            var entity = DbContext.Add(obj);
            DbContext.SaveChanges();

            return entity.Entity;
        }

        public abstract List<T> Get();
        public abstract void Update(long id, T entity);
        public abstract void Delete(long idEntity);

        public virtual T Add(T obj, out ILogger logger) { throw new MethodAccessException(); }
        public virtual bool TryAdd(T obj, out ILogger logger) { throw new MethodAccessException(); }
        public virtual bool TryDelete(long idEntity, out ILogger logger) { throw new MethodAccessException(); }
    }
}

/*
 *public readonly ApplicationDbContext DbContext = dbContext;
   private readonly DbSet<T> _dbSet = dbContext.Set<T>();

   public virtual IQueryable<T> Get() => _dbSet;

   public T Add(T entity)
   {
       if (entity is null) throw new ArgumentNullException();

       DbContext.Entry(entity).State = EntityState.Added;
       DbContext.SaveChanges();

       return entity;
   }

   public async Task<T> AddAsync(T entity, CancellationToken cancel = default)
   {
       if (entity is null) throw new ArgumentNullException();

       DbContext.Entry(entity).State = EntityState.Added;
       await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);

       return entity;
   }

   public void Update(T entity)
   {
       if (entity is null) throw new ArgumentNullException();

       DbContext.Entry(entity).State = EntityState.Modified;
       DbContext.SaveChanges();
   }

   public async Task UpdateAsync(T entity, CancellationToken cancel = default)
   {
       if (entity is null) throw new ArgumentNullException();

       DbContext.Entry(entity).State = EntityState.Modified;
       await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
   }

   public void Delete(long idEntity)
   {
       var entity = _dbSet.Single(l => l.Id == idEntity);
       _dbSet.Remove(entity);
       DbContext.SaveChanges();
   }

   public async Task DeleteAsync(long idEntity, CancellationToken cancel = default)
   {
       var entity = _dbSet.Single(l => l.Id == idEntity);
       _dbSet.Remove(entity);
       await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
   }
 */
