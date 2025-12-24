using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class TeacherRepository
    {
        public readonly ApplicationDbContext DbContext;

        public TeacherRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        

        public bool VerifyTeacher(string login, string password)
             => null != DbContext.Teachers
            .AsNoTracking()
            .Include(t => t.Lessons)
            .FirstOrDefault(t => t.Login == login && t.Password == password);

        public List<TeacherEntity> Get()
            => DbContext.Teachers
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();

        public List<TeacherEntity>? Get(string name, string surname, string patronymic)
            => DbContext.Teachers
            .AsNoTracking()
            .Where(v => v.Name.StartsWith(name))
            .Where(v => v.Surname.StartsWith(surname))
            .Where(v => v.Patronymic.StartsWith(patronymic))
            .ToList();

        public List<TeacherEntity>? Get(int id)
            => DbContext.Teachers
            .AsNoTracking()
            .Where(t => t.Id == id)
            .ToList();

        public void Add(TeacherEntity visitor)
        {
            DbContext.Add(visitor);
            DbContext.SaveChanges();
        }

        public void Update(int id, TeacherEntity visitor)
        {
            DbContext.Teachers
                .Where(v => v.Id == id)
                .ExecuteUpdate(v => v
                    .SetProperty(v => v.Name, visitor.Name)
                    .SetProperty(v => v.Surname, visitor.Surname)
                    .SetProperty(v => v.Patronymic, visitor.Patronymic)
                    .SetProperty(v => v.DateBirth, visitor.DateBirth)
                    .SetProperty(v => v.NumberPhone, visitor.NumberPhone)
                    .SetProperty(v => v.Login, visitor.Login)
                    .SetProperty(v => v.Password, visitor.Password));
        }

        public void Delete(int id)
            => DbContext.Teachers
            .Where(v => v.Id == id)
            .ExecuteDelete();
    }
}
