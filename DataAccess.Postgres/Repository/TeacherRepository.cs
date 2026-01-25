using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class TeacherRepository : Repository<TeacherEntity>
    {
        public TeacherRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public List<TeacherEntity> GetIncludeLessons()
            => DbContext.Teachers
                .Include(t => t.Lessons)
                .ToList() ?? throw new ArgumentNullException();

        public override List<TeacherEntity> Get()
            => DbContext.Teachers
                .Include(t => t.Lessons)
                .ToList() ?? throw new ArgumentNullException();


        public List<TeacherEntity>? Get(int id)
            => DbContext.Teachers
            .AsNoTracking()
            .Where(t => t.Id == id)
            .ToList();

        public override void Update(long id, TeacherEntity visitor)
        {
            DbContext.Teachers
                .Where(v => v.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.FIO, visitor.FIO)
                    .SetProperty(v => v.DateBirth, visitor.DateBirth)
                    .SetProperty(v => v.NumberPhone, visitor.NumberPhone)
                    .SetProperty(v => v.Login, visitor.Login)
                    .SetProperty(v => v.Password, visitor.Password));
        }

        public override void Delete(long idEntity)
        {
            DbContext.Teachers
                .Where(v => v.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
