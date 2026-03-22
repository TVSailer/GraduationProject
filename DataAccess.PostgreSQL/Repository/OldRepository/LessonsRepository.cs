using DataAccess.PostgreSQL.ModelsPrimitive;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository
{
    public class LessonsRepository(ApplicationDbContext dbContext) : Repository<LessonEntity>(dbContext: dbContext)
    {
        public override List<LessonEntity> Get()
            => DbContext.Lessons
                .Include(l => l.Teacher)
                .Include(l => l.Reviews)
                .Include(l => l.Visitors)
                .Include(l => l.AttendanceDates)
                .Include(l => l.Category)
                .Include(l => l.Schedule)
                .Include(l => l.Imgs);

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

            DbContext.SaveChanges();
        }

        public override void Delete(long idEntity)
        {
            DbContext.Lessons
                .Where(predicate: l => l.Id == idEntity)
                .ExecuteDelete();

            DbContext.SaveChanges();
        }
    }
}
