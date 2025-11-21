using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class EventRepository
    {
        public readonly ApplicationDbContext DbContext;
        public EventEntity Event { get; private set; }

        public EventRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public EventRepository(ApplicationDbContext dbContext, EventEntity eventEntity)
        {
            DbContext = dbContext;
            Event = eventEntity;
        }

        public List<EventEntity> Get()
            => DbContext.Events
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();

        public List<EventEntity>? Get(string title, string category, string date)
            => DbContext.Events
            .AsNoTracking()
            .Where(v => v.Title.StartsWith(title))
            .Where(v => v.Category.StartsWith(category))
            .Where(v => v.Date.StartsWith(date))
            .ToList();

        public EventEntity? Get(int id)
            => DbContext.Events
            .AsNoTracking()
            .FirstOrDefault(v => v.Id == id);

        public void Add(EventEntity @event)
        {
            DbContext.Add(@event);
            DbContext.SaveChanges();
        }

        public void Update(int id, EventEntity @event)
        {
            DbContext.Events
                .Where(v => v.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.Title, @event.Title)
                    .SetProperty(v => v.Category, @event.Category)
                    .SetProperty(v => v.Date, @event.Date)
                    .SetProperty(v => v.Organizer, @event.Organizer)
                    .SetProperty(v => v.Location, @event.Location)
                    .SetProperty(v => v.Description, @event.Description)
                    .SetProperty(v => v.MaxParticipants, @event.MaxParticipants)
                    .SetProperty(v => v.CurrentParticipants, @event.CurrentParticipants)
                    .SetProperty(v => v.RegistrationLink, @event.RegistrationLink));
        }

        public void Delete(int id)
            => DbContext.Events
            .Where(v => v.Id == id)
            .ExecuteDelete();
    }
}
