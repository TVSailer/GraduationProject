using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class DateAttendancesRepository : Repository<DateAttendanceEntity>
    {
        public DateAttendancesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override List<DateAttendanceEntity> Get()
           => DbContext.DateAttendances
            .Include(d => d.Visitors)
            .ToList() ?? throw new ArgumentNullException();
        
        public override void Update(long id, DateAttendanceEntity dateAttendance)
            => DbContext.DateAttendances
                .Where(d => d.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.Date, dateAttendance.Date)
                    .SetProperty(v => v.Lesson, dateAttendance.Lesson));

        public override void Delete(long id)
            => DbContext.DateAttendances
            .Where(v => v.Id == id)
            .ExecuteDelete();

    }
}

