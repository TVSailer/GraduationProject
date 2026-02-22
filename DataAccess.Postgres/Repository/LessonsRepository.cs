using DataAccess.Postgres.Extensions;
using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Postgres.Repository
{
    public class LessonsRepository : Repository<LessonEntity>
    {
        public LessonsRepository(ApplicationDbContext dbContext) :  base(dbContext: dbContext)
        {
        }

        public override List<LessonEntity> Get()
          => DbContext.Lessons
            .Include(navigationPropertyPath: l => l.Teacher)
            .Include(navigationPropertyPath: l => l.Reviews)
            .Include(navigationPropertyPath: l => l.Visitors)
            .Include(navigationPropertyPath: l => l.AttendanceDates)
            .Include(navigationPropertyPath: l => l.Category)
            .Include(navigationPropertyPath: l => l.Schedule)
            .Include(navigationPropertyPath: l => l.Imgs)
            .ToList() ?? throw new ArgumentNullException();

        public override void Update(long id, LessonEntity lesson)
        {
            DbContext.Lessons
                .Where(predicate: l => l.Id == id)
                .ExecuteUpdate(setPropertyCalls: l => l
                    .SetProperty(l => l.Name, lesson.Name)
                    .SetProperty(l => l.Description, lesson.Description)
                    .SetProperty(l => l.MaxParticipants, lesson.MaxParticipants)
                    .SetProperty(l => l.CategoryId, lesson.Category.Id)
                    .SetProperty(l => l.Location, lesson.Location)
                    .SetProperty(l => l.TeacherId, lesson.Teacher.Id));


            lesson.Schedule.ForEach(action: ls => DbContext.LessonSchedule
                .Where(predicate: s => s.Id == ls.Id)
                .ExecuteUpdate(setPropertyCalls: s => s
                    .SetProperty(s => s.Start, ls.Start)
                    .SetProperty(s => s.End, ls.End)
                    .SetProperty(s => s.Day, ls.Day)));

            lesson.Schedule
                .Where(predicate: ls => !DbContext.LessonSchedule
                    .Select(selector: s => s.Id)
                    .Contains(item: ls.Id))
                .ToList()
                .ForEach(action: ls => DbContext.Add(entity: ls));

            if (lesson.Imgs != null && lesson.Imgs.Count > 0)
            {
                var lessonDb = DbContext.Lessons
                    .Include(navigationPropertyPath: e => e.Imgs)
                    .FirstOrDefault(predicate: e => e.Id == id);

                if (lessonDb == null)
                {
                    DbContext.SaveChanges();
                    return;
                }

                var existingUrls = lessonDb.Imgs.Select(selector: i => i.Url).ToHashSet();
                var newUrls = lesson.Imgs.Select(selector: i => i.Url).ToHashSet();

                var imgsToRemove = lessonDb.Imgs
                    .Where(predicate: img => !newUrls.Contains(item: img.Url))
                    .ToList();

                foreach (var img in imgsToRemove)
                    lessonDb.Imgs.Remove(item: img);

                foreach (var img in lesson.Imgs)
                    if (!existingUrls.Contains(item: img.Url))
                        lessonDb.Imgs.Add(item: img);
            }

            DbContext.SaveChanges();
        }

        public override void Delete(long idEntity)
        {
            DbContext.Lessons
                .Where(predicate: l => l.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
