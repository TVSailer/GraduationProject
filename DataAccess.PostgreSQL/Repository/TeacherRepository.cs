using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class TeacherRepository(ApplicationDbContext dbContext, AuthRepository authRepository) : Repository<TeacherEntity>(dbContext: dbContext)
    {
        public override List<TeacherEntity> Get()
            => DbContext.Teachers
                .Include(navigationPropertyPath: t => t.Lessons)
                .Include(navigationPropertyPath: t => t.AuthEntity)
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
            TryDelete(idEntity, out _);
        }

        public override TeacherEntity Add(TeacherEntity obj, out ILogger logger)
        {
            if (obj is null) throw new ArgumentNullException();

            obj.AuthEntity = authRepository.AddAuthUser(obj.FIO, out logger);

            return Add(obj);
        }

        public override bool TryDelete(long idEntity, out ILogger log)
        {
            var t = DbContext.Teachers
                .Include(teacherEntity => teacherEntity.Lessons)
                .Single(predicate: v => v.Id == idEntity);

            if (t.Lessons is not { Count: 0 })
            {
                log = new RepositoryLogger("Для удаления преподователь не должен вести ни каких урков!");
                return false;
            }

            DbContext.Teachers.Remove(t);
            DbContext.SaveChanges();

            log = new RepositoryLogger("");
            return true;
        }
    }
}
