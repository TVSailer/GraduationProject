using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Domain.Repository;

public interface IRepository<T>
    where T : Entity
{
    T Add(T entity);
    IQueryable<T> Get();
    void Update(T entity);
    void Delete(long idEntity);
    
    Task<EntityEntry<T>> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(long idEntity);
}