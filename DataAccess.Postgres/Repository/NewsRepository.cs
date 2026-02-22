using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class NewsRepository(ApplicationDbContext dbContext) : Repository<NewsEntity>(dbContext: dbContext)
    {
        public override List<NewsEntity> Get()
            => DbContext.News
            .Include(navigationPropertyPath: e => e.Imgs)
            .AsNoTracking()
            .ToList();

        public NewsEntity Get(int id)
            => DbContext.News
            .AsNoTracking()
            .Include(navigationPropertyPath: e => e.Imgs)
            .FirstOrDefault(predicate: v => v.Id == id) ?? throw new ArgumentNullException();

        public override void Update(long id, NewsEntity news)
        {
            DbContext.News
                .Where(predicate: n => n.Id == id)
                .ExecuteUpdate(setPropertyCalls: n => n
                    .SetProperty(n => n.Title, news.Title)
                    .SetProperty(n => n.Category, news.Category)
                    .SetProperty(n => n.Date, news.Date)
                    .SetProperty(n => n.Content, news.Content)
                    .SetProperty(n => n.Author, news.Author));

            if (news.Imgs == null || news.Imgs.Count == 0) return;

            var listImgDb = DbContext.ImgNews
                .Where(predicate: img => img.News.Id == id)
                .ToList();

            var listImg = news.Imgs;

            listImgDb
                .ForEach(
                action: imgDb =>
                {
                    if (!listImg.Select(selector: img => img.Url).Contains(value: imgDb.Url))
                        DbContext.ImgNews.Remove(entity: imgDb);
                });

            listImg
                .ForEach(
                action: img =>
                {
                    if (!listImgDb.Select(selector: img => img.Url).Contains(value: img.Url))
                        DbContext.News.FirstOrDefault(predicate: ev => ev.Id == id).Imgs.Add(item: img);
                });

            DbContext.SaveChanges();
        }

        public override void Delete(long idEntity)
        {
            DbContext.News
                .Where(predicate: v => v.Id == idEntity)
                .ExecuteDelete();
        }
    }
}
