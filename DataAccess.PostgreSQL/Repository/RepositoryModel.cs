using CSharpFunctionalExtensions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository;

internal class RepositoryModel<T>(ApplicationDbContext DbContext) : IRepository<T>
    where T : Entity
{
    private readonly DbSet<T> _dbSet = DbContext.Set<T>();

    public IQueryable<T> Get() => SettingDbSet(_dbSet);

    protected virtual IQueryable<T> SettingDbSet(DbSet<T> dbSet) => _dbSet;

    public T Add(T entity)
    {
        if (entity is null) throw new ArgumentNullException();
        return _dbSet.Add(entity).Entity;
    }

    public void Update(T entity)
    {
        if (entity is null) throw new ArgumentNullException();
        _dbSet.Update(entity);
    }

    public void Delete(long idEntity)
    {
        var entity = _dbSet.Single(l => l.Id == idEntity);
        _dbSet.Remove(entity);
    }
}