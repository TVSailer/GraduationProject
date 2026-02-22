using DataAccess.Postgres.Models;

namespace DataAccess.Postgres.Repository
{
    public class LessonCategoryRepositroy : Repository<LessonCategoryEntity>
    {
        public LessonCategoryRepositroy(ApplicationDbContext dbContext) : base(dbContext: dbContext)
        {
        }


        public override List<LessonCategoryEntity> Get()
            => DbContext.LessonCategory
                .ToList();

        public override void Update(long id, LessonCategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(long idEntity)
        {
            throw new NotImplementedException();
        }
    }
}