using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class VisitorsRepository
    {
        public readonly ApplicationDbContext DbContext;
        public VisitorEntity Visitor { get; private set; }
        public VisitorsRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<VisitorEntity> Get()
            => DbContext.Visitors
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();

        public bool VerifyVisitor(string login, string password)
        {
            Visitor = DbContext.Visitors
            .AsNoTracking()
            .FirstOrDefault(v => v.Login == login && v.Password == password);

            return Visitor != null;
        }
        public List<VisitorEntity> Get(string name, string surname, string patronymic)
            => DbContext.Visitors
            .AsNoTracking()
            .Where(v => v.Name.StartsWith(name))
            .Where(v => v.Surname.StartsWith(surname))
            .Where(v => v.Patronymic.StartsWith(patronymic))
            .ToList() ?? throw new ArgumentNullException();

        public List<VisitorEntity>? GetVisitorsLesson(int idLesson)
            => DbContext.Visitors
            .Include(v => v.Lessons)
            .AsNoTracking()
            .Where(v => v.Lessons.Where(l => l.Id == idLesson) != null)
            .ToList();
        
        public List<VisitorEntity> Get(int id)
            => DbContext.Visitors
            .AsNoTracking()
            .Where(v => v.Id == id)
            .ToList() ?? throw new ArgumentNullException();

        public void Add(string name, string surname, string patronymic, string dateBirth, string numberPhone, List<LessonEntity> lessons, string login, string password, LessonEntity lesson)
        {
            var visitor = new VisitorEntity()
            {
                Name = name,
                Surname = surname,
                Patronymic = patronymic,
                DateBirth = dateBirth,
                NumberPhone = numberPhone,
                Lessons = lessons,
                Login = login,
                Password = password
            };

            DbContext.Add(visitor);
            DbContext.SaveChanges();
        }
        
        public void Add(VisitorEntity visitor)
        {
            DbContext.Add(visitor);
            DbContext.SaveChanges();
        }
        
        public void Update(int id, string name, string surname, string patronymic, string dateBirth, string numberPhone, ICollection<LessonEntity> lessons, string login, string password)
            => DbContext.Visitors
                .Where(v => v.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.Name, name)
                    .SetProperty(v => v.Surname, surname)
                    .SetProperty(v => v.Patronymic, patronymic)
                    .SetProperty(v => v.DateBirth, dateBirth)
                    .SetProperty(v => v.NumberPhone, numberPhone)
                    .SetProperty(v => v.Login, login)
                    .SetProperty(v => v.Password, password));

        public void Update(int id, VisitorEntity visitor)
            => DbContext.Visitors
                .Where(v => v.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.Name, visitor.Name)
                    .SetProperty(v => v.Surname, visitor.Surname)
                    .SetProperty(v => v.Patronymic, visitor.Patronymic)
                    .SetProperty(v => v.DateBirth, visitor.DateBirth)
                    .SetProperty(v => v.NumberPhone, visitor.NumberPhone)
                    .SetProperty(v => v.Login, visitor.Login)
                    .SetProperty(v => v.Password, visitor.Password));

        public void Delete(int id)
            => DbContext.Visitors
            .Where(v => v.Id == id)
            .ExecuteDelete();

    }
}
