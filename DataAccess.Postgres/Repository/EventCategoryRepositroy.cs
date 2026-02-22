using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository;

public class EventCategoryRepository : Repository<EventCategoryEntity>
{
    public EventCategoryRepository(ApplicationDbContext dbContext) : base(dbContext: dbContext)
    {
    }

    public override List<EventCategoryEntity> Get()
        => DbContext.EventCategory
            .ToList();

    public override void Update(long id, EventCategoryEntity entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(long idEntity)
    {
        throw new NotImplementedException();
    }
}