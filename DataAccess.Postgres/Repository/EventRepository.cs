using CSharpFunctionalExtensions;
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
                    .SetProperty(v => v.Category, @event.Category)
                    .SetProperty(v => v.Schedule, @event.Schedule)
                    .SetProperty(v => v.Organizer, @event.Organizer)
                    .SetProperty(v => v.Location, @event.Location)
                    .SetProperty(v => v.Description, @event.Description)
                    .SetProperty(v => v.MaxParticipants, @event.MaxParticipants)
                    .SetProperty(v => v.CurrentParticipants, @event.CurrentParticipants)
                    .SetProperty(v => v.RegistrationLink, @event.RegistrationLink));

            if (@event.Imgs == null || @event.Imgs.Count == 0) return;

            var listImgDb = DbContext.ImgEvent
                .Where(img => img.Event.Id == id)
                .ToList();

            var listImg = @event.Imgs;

            listImgDb
                .ForEach(
                imgDb =>
                {
                    if (!listImg.Select(img => img.Url).Contains(imgDb.Url))
                        DbContext.ImgEvent.Remove(imgDb);
                });

            listImg
                .ForEach(
                img =>
                {
                    if (!listImgDb.Select(img => img.Url).Contains(img.Url))
                        DbContext.Event.FirstOrDefault(ev => ev.Id == id).Imgs.Add(img);
                });

            DbContext.SaveChanges();
        }

        public override void Delete(EventEntity entity)
            => DbContext.Event
            .Where(v => v.Id == entity.Id)
            .ExecuteDelete();
    }
}
