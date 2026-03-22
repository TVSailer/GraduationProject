using DataAccess.PostgreSQL.ModelsPrimitive;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository
{
    internal partial class EventRepository(ApplicationDbContext dbContext) : Repository<EventEntity>(dbContext: dbContext)
    {
        public override List<EventEntity> Get()
            => DbContext.Events
            .Include(e => e.Imgs)
            .Include(e => e.Category)
            .ToList() ?? throw new ArgumentNullException();

        public override void Update(long id, EventEntity @event)
        {
            DbContext.Events
                .Where(predicate: v => v.Id == id)
                .ExecuteUpdate(setPropertyCalls: v => v
                    .SetProperty(v => v.Title, @event.Title)
                    .SetProperty(v => v.Category, @event.Category)
                    .SetProperty(v => v.Schedule, @event.Schedule)
                    .SetProperty(v => v.UrlTitleImag, @event.UrlTitleImag)
                    .SetProperty(v => v.Organizer, @event.Organizer)
                    .SetProperty(v => v.Location, @event.Location)
                    .SetProperty(v => v.Description, @event.Description)
                    .SetProperty(v => v.RegistrationLink, @event.RegistrationLink));
        }

        public override void Delete(long idEntity)
            => DbContext.Events
            .Where(predicate: v => v.Id == idEntity)
            .ExecuteDelete();
    }
}
