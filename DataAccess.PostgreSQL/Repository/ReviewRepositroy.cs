namespace DataAccess.PostgreSQL.Repository;

public class ReviewRepository(ApplicationDbContext dbContext) : Repository<ReviewEntity>(dbContext)
{
    public override List<ReviewEntity> Get()
    {
        throw new NotImplementedException();
    }

    public override void Update(long id, ReviewEntity entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(long idEntity)
    {
        throw new NotImplementedException();
    }
}