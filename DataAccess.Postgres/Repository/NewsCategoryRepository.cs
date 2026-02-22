using DataAccess.Postgres.Models;

namespace DataAccess.Postgres.Repository;

public class NewsCategoryRepository(ApplicationDbContext dbContext)
    : Repository<NewsCategoryEntity>(dbContext: dbContext)
{
    public override List<NewsCategoryEntity> Get()
        => DbContext.NewsCategory.ToList();

    public override void Update(long id, NewsCategoryEntity entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(long idEntity)
    {
        throw new NotImplementedException();
    }
}