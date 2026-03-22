using CSharpFunctionalExtensions;

namespace Domain.Repository;

public interface IRepository<T>
    where T : Entity
{
    T Add(T entity);
    IQueryable<T> Get();
    void Update(T entity);
    void Delete(long idEntity);
}