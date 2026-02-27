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
        }

        public override void Delete(long idEntity)
        {
            DbContext.Lessons
                .Where(predicate: l => l.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
