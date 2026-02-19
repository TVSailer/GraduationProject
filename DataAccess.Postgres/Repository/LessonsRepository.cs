using DataAccess.Postgres.Extensions;
using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Postgres.Repository
{
    public class LessonsRepository : Repository<LessonEntity>
    {
        public LessonsRepository(ApplicationDbContext dbContext) :  base(dbContext)
        {
        }

        public override List<LessonEntity> Get()
          => DbContext.Lessons
            .Include(l => l.Teacher)
            .Include(l => l.Reviews)
            .Include(l => l.Visitors)
            .Include(l => l.AttendanceDates)
            .Include(l => l.Category)
            .Include(l => l.Schedule)
            .Include(l => l.Imgs)
            .ToList() ?? throw new ArgumentNullException();

        public override void Update(long id, LessonEntity lesson)
        {
            DbContext.Lessons
                .Where(l => l.Id == id)
                .ExecuteUpdate(l => l
                    .SetProperty(l => l.Name, lesson.Name)
                    .SetProperty(l => l.Description, lesson.Description)
                    .SetProperty(l => l.MaxParticipants, lesson.MaxParticipants)
                    .SetProperty(l => l.CategoryId, lesson.Category.Id)
                    .SetProperty(l => l.Location, lesson.Location)
                    .SetProperty(l => l.TeacherId, lesson.Teacher.Id));


            lesson.Schedule.ForEach(ls => DbContext.LessonSchedule
                .Where(s => s.Id == ls.Id)
                .ExecuteUpdate(s => s
                    .SetProperty(s => s.Start, ls.Start)
                    .SetProperty(s => s.End, ls.End)
                    .SetProperty(s => s.Day, ls.Day)));

            lesson.Schedule
                .Where(ls => !DbContext.LessonSchedule
                    .Select(s => s.Id)
                    .Contains(ls.Id))
                .ToList()
                .ForEach(ls => DbContext.Add(ls));

            if (lesson.Imgs != null && lesson.Imgs.Count > 0)
            {
                var lessonDb = DbContext.Lessons
                    .Include(e => e.Imgs)
                    .FirstOrDefault(e => e.Id == id);

                if (lessonDb == null)
                {
                    DbContext.SaveChanges();
                    return;
                }

                var existingUrls = lessonDb.Imgs.Select(i => i.Url).ToHashSet();
                var newUrls = lesson.Imgs.Select(i => i.Url).ToHashSet();

                var imgsToRemove = lessonDb.Imgs
                    .Where(img => !newUrls.Contains(img.Url))
                    .ToList();

                foreach (var img in imgsToRemove)
                    lessonDb.Imgs.Remove(img);

                foreach (var img in lesson.Imgs)
                    if (!existingUrls.Contains(img.Url))
                        lessonDb.Imgs.Add(img);
            }

            DbContext.SaveChanges();
        }

        public override void Delete(long idEntity)
        {
            DbContext.Lessons
                .Where(l => l.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
