using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class TeacherRepository : Repository<TeacherEntity>
    {
        public TeacherRepository(ApplicationDbContext dbContext) : base(dbContext: dbContext)
        {
        }

        public List<TeacherEntity> GetIncludeLessons()
            => DbContext.Teachers
                .Include(navigationPropertyPath: t => t.Lessons)
                .Include(navigationPropertyPath: t => t.AuthEntity)
                .ToList() ?? throw new ArgumentNullException();

        public override List<TeacherEntity> Get()
            => DbContext.Teachers
                .Include(navigationPropertyPath: t => t.Lessons)
                .ToList() ?? throw new ArgumentNullException();


        public List<TeacherEntity>? Get(int id)
            => DbContext.Teachers
            .AsNoTracking()
            .Where(predicate: t => t.Id == id)
            .ToList();

        public override void Update(long id, TeacherEntity teacher)
        {
            DbContext.Teachers
                .Where(predicate: v => v.Id == id)
                .ExecuteUpdate(setPropertyCalls: v => v
                    .SetProperty(v => v.FIO, teacher.FIO)
                    .SetProperty(v => v.DateBirth, teacher.DateBirth)
                    .SetProperty(v => v.NumberPhone, teacher.NumberPhone)
                    .SetProperty(v => v.AuthEntity, teacher.AuthEntity));
        }

        public override void Delete(long idEntity)
        {
            DbContext.Teachers
                .Where(predicate: v => v.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
