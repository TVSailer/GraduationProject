using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.PostgreSQL;
using DataAccess.PostgreSQL.ModelsPrimitive;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository
{
    public class DateAttendancesRepository : Repository<DateAttendanceEntity>
    {
        public DateAttendancesRepository(ApplicationDbContext dbContext) : base(dbContext: dbContext)
        {
        }

        public override List<DateAttendanceEntity> Get()
           => DbContext.DateAttendances
            .Include(d => d.Visitors)
            .ToList() ?? throw new ArgumentNullException();
        
        public override void Update(long id, DateAttendanceEntity dateAttendance)
            => DbContext.DateAttendances
                .Where(predicate: d => d.Id == id)
                .ExecuteUpdate(setPropertyCalls: v => v
                    .SetProperty(v => v.Date, dateAttendance.Date)
                    .SetProperty(v => v.Lesson, dateAttendance.Lesson));

        public override void Delete(long id)
            => DbContext.DateAttendances
            .Where(predicate: v => v.Id == id)
            .ExecuteDelete();
    }
}

