using DataAccess.Postgres.Models;

namespace DataAccess.Postgres.Repository;

public class EventCategoryRepositroy : Repository<EventCategoryEntity>
{
    public EventCategoryRepositroy(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override List<EventCategoryEntity> Get()
        => DbContext.EventCategory
            .ToList();

    public override void Update(long id, EventCategoryEntity entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(EventCategoryEntity entity)
    {
        throw new NotImplementedException();
    }
}