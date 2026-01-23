using DataAccess.Postgres.Models;

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
                .ToList();

        public override void Update(long id, LessonCategoryEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}