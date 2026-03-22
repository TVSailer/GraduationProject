using DataAccess.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Repository
{
    public class NewsRepository(ApplicationDbContext dbContext) : Repository<NewsModel>(dbContext: dbContext)
    {
        public override List<NewsModel> Get()
            => DbContext.NewsModels
            .Include(navigationPropertyPath: e => e.Images)
            .Include(navigationPropertyPath: e => e.Category)
            .ToList();

        public override void Update(long id, NewsModel news)
        {
            DbContext.NewsModels
                .Where(predicate: n => n.Id == id)
                .ExecuteUpdate(n => n
                    .SetProperty(n => n.TitleP, news.TitleP)
                    .SetProperty(n => n.Category, news.Category)
                    .SetProperty(n => n.Date, news.Date)
                    .SetProperty(n => n.DescriptionP, news.DescriptionP)
                    .SetProperty(n => n.Author, news.Author));

            DbContext.SaveChanges();
        }

        public override void Delete(long idEntity)
        {
            DbContext.NewsModels
                .Where(predicate: v => v.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
