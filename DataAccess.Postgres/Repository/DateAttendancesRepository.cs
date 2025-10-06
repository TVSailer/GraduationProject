using DataAccess.Postgres.Models;
using Logica;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class DateAttendancesRepository
    {
        public readonly ApplicationDbContext DbContext;

        public DateAttendancesRepository(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public List<DateAttendanceEntity> Get(int idLesson)
           => DbContext.DateAttendances
            //.Include(d => d.Lesson)
            .Include(d => d.Visitors)
            .Where(d => d.Lesson.Id == idLesson)
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();
        
        public List<DateAttendanceEntity>? Get(string startDate, string endDate)
            => DbContext.DateAttendances
            .AsNoTracking()
            .Where(d => d.Date.DateMatchingTheInterval(startDate, endDate))
            .ToList();

        public void Add(DateAttendanceEntity dateAttendance)
        {
            DbContext.Add(dateAttendance);
            DbContext.SaveChanges();
        }

        public void AddRelationWithLesson(DateAttendanceEntity date, LessonEntity lesson)
        {
            DbContext.DateAttendances.FirstOrDefault(d => d.Id == date.Id).LessonId = lesson.Id;
            DbContext.SaveChanges();
        }

        public void AddRelationWithVisitor(DateAttendanceEntity date, VisitorEntity visitor)
        {
            DbContext.DateAttendances.FirstOrDefault(d => d.Id == date.Id)
                .Visitors.Add(DbContext.Visitors.FirstOrDefault(v => v.Id == visitor.Id));
            DbContext.SaveChanges();
        }

        public void Update(int id, string date, LessonEntity lesson)
            => DbContext.DateAttendances
                .Where(d => d.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.Date, date)
                    .SetProperty(v => v.Lesson, lesson));
        
        public void Update(int id, DateAttendanceEntity dateAttendance)
            => DbContext.DateAttendances
                .Where(d => d.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.Date, dateAttendance.Date)
                    .SetProperty(v => v.Lesson, dateAttendance.Lesson));

        public void Delete(int id)
            => DbContext.DateAttendances
            .Where(v => v.Id == id)
            .ExecuteDelete();

    }
}
