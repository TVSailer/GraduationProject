using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class EventRepository(ApplicationDbContext dbContext) : Repository<EventEntity>(dbContext: dbContext)
    {
        public override List<EventEntity> Get()
            => DbContext.Events
            .Include(e => e.Imgs)
            .Include(e => e.Category)
            .ToList() ?? throw new ArgumentNullException();

        public EventEntity Get(long id)
            => DbContext.Events
            .AsNoTracking()
            .Include(navigationPropertyPath: e => e.Imgs)
            .FirstOrDefault(predicate: v => v.Id == id) ?? throw new ArgumentNullException();

        public override void Update(long id, EventEntity @event)
        {
            DbContext.Events
                .Where(predicate: v => v.Id == id)
                .ExecuteUpdate(setPropertyCalls: v => v
                    .SetProperty(v => v.Title, @event.Title)
                    .SetProperty(v => v.CategoryId, @event.Category.Id)
                    .SetProperty(v => v.Schedule, @event.Schedule)
                    .SetProperty(v => v.Organizer, @event.Organizer)
                    .SetProperty(v => v.Location, @event.Location)
                    .SetProperty(v => v.Description, @event.Description)
                    .SetProperty(v => v.MaxParticipants, @event.MaxParticipants)
                    .SetProperty(v => v.CurrentParticipants, @event.CurrentParticipants)
                    .SetProperty(v => v.RegistrationLink, @event.RegistrationLink));
        }

        public override void Delete(long idEntity)
            => DbContext.Events
            .Where(predicate: v => v.Id == idEntity)
            .ExecuteDelete();
    }
}
