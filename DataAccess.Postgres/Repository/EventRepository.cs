using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class EventRepository : Repository<EventEntity>
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public override List<EventEntity> Get()
            => DbContext.Event
            .Include(e => e.Imgs)
            .Include(e => e.Category)
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();

        public EventEntity Get(long id)
            => DbContext.Event
            .AsNoTracking()
            .Include(e => e.Imgs)
            .FirstOrDefault(v => v.Id == id) ?? throw new ArgumentNullException();

        public override void Update(long id, EventEntity @event)
        {
            DbContext.Event
                .Where(v => v.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.Title, @event.Title)
                    .SetProperty(v => v.CategoryId, @event.Category.Id)
                    .SetProperty(v => v.Schedule, @event.Schedule)
                    .SetProperty(v => v.Organizer, @event.Organizer)
                    .SetProperty(v => v.Location, @event.Location)
                    .SetProperty(v => v.Description, @event.Description)
                    .SetProperty(v => v.MaxParticipants, @event.MaxParticipants)
                    .SetProperty(v => v.CurrentParticipants, @event.CurrentParticipants)
                    .SetProperty(v => v.RegistrationLink, @event.RegistrationLink));

            var sdlf = DbContext.Event.Where(e => e.Id == id);

            if (@event.Imgs != null && @event.Imgs.Count > 0)
            {
                @event.Imgs.ForEach(imgl => DbContext.ImgEvent
                    .Where(img => img.Id == imgl.Id)
                    .ExecuteUpdate(s => s
                        .SetProperty(i => i.Url, imgl.Url)));

                @event.Imgs
                    .Where(imgL => !DbContext.ImgEvent
                        .Select(i => i.Id)
                        .Contains(imgL.Id))
                    .ToList()
                    .ForEach(img => DbContext.Add(img));
            }

            DbContext.SaveChanges();
        }

        public override void Delete(long idEntity)
            => DbContext.Event
            .Where(v => v.Id == idEntity)
            .ExecuteDelete();
    }
}
