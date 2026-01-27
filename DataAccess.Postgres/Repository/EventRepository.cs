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
            //.AsNoTracking()
            .AsTracking()
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

            if (@event.Imgs is { Count: > 0 })
            {
                var eventDb = DbContext.Event
                    .Include(e => e.Imgs) 
                    .FirstOrDefault(e => e.Id == id);

                if (eventDb == null)
                {
                    DbContext.SaveChanges();
                    return;
                }

                var existingUrls = eventDb.Imgs.Select(i => i.Url).ToHashSet();
                var newUrls = @event.Imgs.Select(i => i.Url).ToHashSet();

                var imgsToRemove = eventDb.Imgs
                    .Where(img => !newUrls.Contains(img.Url))
                    .ToList();

                foreach (var img in imgsToRemove)
                    eventDb.Imgs.Remove(img);

                foreach (var img in @event.Imgs)
                    if (!existingUrls.Contains(img.Url))
                        eventDb.Imgs.Add(img);

                // var listImgDb = DbContext.ImgEvent
                //     .Where(img => img.EventId == id)
                //     .ToList();
                //
                // var listImg = @event.Imgs;
                //
                // listImgDb
                //     .ForEach(
                //         imgDb =>
                //         {
                //             if (!listImg.Select(img => img.Url).Contains(imgDb.Url))
                //                 DbContext.ImgEvent.Remove(imgDb);
                //         });
                //
                // listImg
                //     .ForEach(
                //         img =>
                //         {
                //             if (!listImgDb.Select(imgDb => imgDb.Id).Contains(img.Id))
                //                 DbContext.Event.FirstOrDefault(ev => ev.Id == id).Imgs.Add(img);
                //         });
                // // 1. Сохраняем ID для проверки (ДО любых изменений)
                // var existingIdsBeforeChanges = DbContext.ImgEvent
                //     .Select(i => i.Id)
                //     .ToHashSet();
                //
                // // 2. Удаляем то, что не в @event.Imgs
                // DbContext.ImgEvent
                //     .Where(img => !@event.Imgs.Select(e => e.Id).Contains(img.Id))
                //     .ExecuteDelete();
                //
                // // 3. Добавляем только то, чего действительно не было
                // var imgsToAdd = @event.Imgs
                //     .Where(img => !existingIdsBeforeChanges.Contains(img.Id))
                //     .ToList();
                //
                // if (imgsToAdd.Any())
                //     DbContext.ImgEvent.AddRange(imgsToAdd);
                //
                // // @event.Imgs.ForEach(imgl => DbContext.ImgEvent
                // //     .Where(img => img.Id == imgl.Id)
                // //     .ExecuteUpdate(s => s
                // //         .SetProperty(i => i.Url, imgl.Url)));
                // // @event.Imgs
                // //     .Where(imgL => !DbContext.ImgEvent
                // //         .Select(i => i.Id)
                // //         .Contains(imgL.Id))
                // //     .ToList()
                // //     .ForEach(img => 
                // //         DbContext.Add(img));
            }

            DbContext.SaveChanges();
        }

        public override void Delete(long idEntity)
            => DbContext.Event
            .Where(v => v.Id == idEntity)
            .ExecuteDelete();
    }
}
