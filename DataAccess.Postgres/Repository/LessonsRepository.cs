using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Postgres.Repository
{
    public class LessonsRepository : Repository<LessonEntity>
    {
        public LessonsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override List<LessonEntity> Get()
          => DbContext.Lessons
            .Include(l => l.Teacher)
            .Include(l => l.Category)
            .Include(l => l.Schedule)
            .Include(l => l.Imgs)
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();

        public LessonEntity Get(int id)
            => DbContext.Lessons
            .Include(l => l.Visitors)
            .Include(l => l.Teacher)
            .Include(l => l.AttendanceDates)
            .AsNoTracking()
            .FirstOrDefault(l => l.Id == id) ?? throw new ArgumentNullException();

        public LessonEntity Get(string name)
            => DbContext.Lessons
            .Include(l => l.Visitors)
            .Include(l => l.Teacher)
            .Include(l => l.AttendanceDates)
            .AsNoTracking()
            .FirstOrDefault(l => l.Name == name) ?? throw new ArgumentNullException();

        //public List<LessonEntity> Get(string name, string surnameTeacher)
        //    => DbContext.Lessons
        //    .Include(l => l.Teacher)
        //    .AsNoTracking()
        //    .Where(l => l.Name.StartsWith(name))
        //    .Where(l => l.Teacher. Surname.StartsWith(surnameTeacher))
        //    .ToList() ?? throw new ArgumentNullException();

        //public List<VisitorEntity> GetVisitors(int lessonId, string name, string surname, string patro)
        //    => Get(lessonId).Visitors
        //    .Where(v => v.Name.StartsWith(name))
        //    .Where(v => v.Surname.StartsWith(surname))
        //    .Where(v => v.Patronymic.StartsWith(patro))
        //    .ToList() ?? throw new ArgumentNullException();

        public void AddRelationWithVisitor(LessonEntity lesson, VisitorEntity visitor)
        {
            DbContext.Lessons.FirstOrDefault(l => l.Id == lesson.Id).Visitors.Add(visitor);
            DbContext.SaveChanges();
        }
        public void AddRelationWithDateAttendance(LessonEntity lesson, DateAttendanceEntity date)
        {
            DbContext.Lessons.FirstOrDefault(l => l.Id == lesson.Id).AttendanceDates.Add(date);
            DbContext.SaveChanges();
        }

        public void Add(LessonEntity lesson)
        {
            var tc = DbContext.Teachers.FirstOrDefault(t => t.Id == lesson.Teacher.Id) ?? throw new ArgumentNullException();
            var cat = DbContext.LessonCategory.FirstOrDefault(c => c.Id == lesson.Category.Id) ?? throw new ArgumentNullException();

            tc.Lessons.Add(lesson);
            cat.LessonEntities.Add(lesson);
            DbContext.SaveChanges();
        }

        public override void Update(long id, LessonEntity lesson)
        {
            DbContext.Lessons
                .Where(l => l.Id == id)
                .ExecuteUpdate(l => l
                    .SetProperty(l => l.Name, lesson.Name)
                    .SetProperty(l => l.Description, lesson.Description)
                    .SetProperty(l => l.MaxParticipants, lesson.MaxParticipants)
                    .SetProperty(l => l.CategoryId, lesson.CategoryId)
                    .SetProperty(l => l.Location, lesson.Location)
                    .SetProperty(l => l.TeacherId, lesson.Teacher.Id));


            if (lesson.Schedule != null || lesson.Schedule.Count > 0)
            {
                DbContext.LessonSchedule
                    .Where(s => s.LessonId == id)
                    .ToList()
                    .ForEach(s => DbContext.Remove(s));

                lesson.Schedule
                    .ForEach(s => DbContext.Add(s));
            }


            if (lesson.Imgs != null || lesson.Imgs.Count > 0)
            {
                DbContext.ImgLesson
                    .Where(img => img.Lesson.Id == id)
                    .ToList()
                    .ForEach(img => DbContext.Remove(img));

                lesson.Imgs
                    .ForEach(img => DbContext.Add(img));
            }


            //listImgDb
            //    .ForEach(
            //    imgDb =>
            //    {
            //        if (!listImg.Select(img => img.Url).Contains(imgDb.Url))
            //            DbContext.ImgLesson.Remove(imgDb);
            //    });

            //listImg
            //    .ForEach(
            //    img =>
            //    {
            //        if (!listImgDb.Select(img => img.Url).Contains(img.Url))
            //            DbContext.Lessons.FirstOrDefault(les => les.Id == id).Imgs.Add(img);
            //    });

            DbContext.SaveChanges();
        }

        public override void Delete(LessonEntity lesson)
           => DbContext.Lessons
           .Where(l => l.Id == lesson.Id)
           .ExecuteDelete();
    }
}
