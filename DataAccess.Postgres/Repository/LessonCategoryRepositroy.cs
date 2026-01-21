using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class LessonCategoryRepositroy : Repository<LessonCategoryEntity>
    {
        public LessonCategoryRepositroy(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(LessonCategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<LessonCategoryEntity> Get()
            => DbContext.LessonCategory
            .AsNoTracking()
            .ToList();

        public override void Update(long id, LessonCategoryEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
