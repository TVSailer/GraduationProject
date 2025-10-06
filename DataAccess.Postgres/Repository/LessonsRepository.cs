using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class LessonsRepository
    {
        public readonly ApplicationDbContext DbContext;

        public LessonsRepository(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public List<LessonEntity> Get()
          => DbContext.Lessons
            .Include(l => l.Teacher)
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();

        public LessonEntity Get(int id)
            => DbContext.Lessons
            .Include(l => l.Visitors)
            .Include(l => l.Teacher)
            .Include(l => l.Dates)
            .AsNoTracking()
            .FirstOrDefault(l => l.Id == id) ?? throw new ArgumentNullException();
        
        public LessonEntity Get(string name)
            => DbContext.Lessons
            .Include(l => l.Visitors)
            .Include(l => l.Teacher)
            .Include(l => l.Dates)
            .AsNoTracking()
            .FirstOrDefault(l => l.Name == name) ?? throw new ArgumentNullException();

        public List<LessonEntity> Get(string name, string surnameTeacher)
            => DbContext.Lessons
            .Include(l => l.Teacher)
            .AsNoTracking()
            .Where(l => l.Name.StartsWith(name))
            .Where(l => l.Teacher.Surname.StartsWith(surnameTeacher))
            .ToList() ?? throw new ArgumentNullException();

        public List<VisitorEntity> GetVisitors(int lessonId, string name, string surname, string patro)
            => Get(lessonId).Visitors
            .Where(v => v.Name.StartsWith(name))
            .Where(v => v.Surname.StartsWith(surname))
            .Where(v => v.Patronymic.StartsWith(patro))
            .ToList() ?? throw new ArgumentNullException();

        public void Add(LessonEntity lesson)
        {
            DbContext.Add(lesson);
            DbContext.SaveChanges();
        }

        public void AddRelationWithVisitor(LessonEntity lesson, VisitorEntity visitor)
        {
            DbContext.Lessons.FirstOrDefault(l => l.Id == lesson.Id).Visitors.Add(visitor);
            DbContext.SaveChanges();
        }
        public void AddDate(LessonEntity lesson, DateAttendanceEntity date)
        {
            DbContext.Lessons.FirstOrDefault(l => l.Id == lesson.Id).Dates.Add(date);
            DbContext.SaveChanges();
        }

        public void Update(int id, string name, TeacherEntity teacher, List<DateAttendanceEntity>? dates, List<VisitorEntity>? visitors)
           => DbContext.Lessons
               .Where(l => l.Id == id)
               .ExecuteUpdate(l => l
                    .SetProperty(l => l.Name, name)
                    .SetProperty(l => l.Teacher, teacher)
                    .SetProperty(l => l.Dates, dates)
                    .SetProperty(l => l.Visitors, visitors));

        public void Update(int id, LessonEntity lesson)
            => DbContext.Lessons
                .Where(l => l.Id == id)
                .ExecuteUpdate(l => l
                    .SetProperty(l => l.Name, lesson.Name)
                    .SetProperty(l => l.TeacherId, lesson.Teacher.Id)
                    .SetProperty(l => l.Dates, lesson.Dates)
                    .SetProperty(l => l.Visitors, lesson.Visitors));

        public void Delete(int id)
           => DbContext.Lessons
           .Where(l => l.Id == id)
           .ExecuteDelete();
    }
}
