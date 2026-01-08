using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class NewsRepository : Repository<NewsEntity>
    {
        public NewsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public override List<NewsEntity> Get()
            => DbContext.News
            .Include(e => e.ImgsNews)
            .AsNoTracking()
            .ToList();

        public NewsEntity Get(int id)
            => DbContext.News
            .AsNoTracking()
            .Include(e => e.ImgsNews)
            .FirstOrDefault(v => v.Id == id) ?? throw new ArgumentNullException();

        public override void Update(long id, NewsEntity news)
        {
            DbContext.News
                .Where(n => n.Id == id)
                .ExecuteUpdate(n => n
                    .SetProperty(n => n.Title, news.Title)
                    .SetProperty(n => n.Category, news.Category)
                    .SetProperty(n => n.Date, news.Date)
                    .SetProperty(n => n.Content, news.Content)
                    .SetProperty(n => n.Author, news.Author));

            if (news.ImgsNews == null || news.ImgsNews.Count == 0) return;

            var listImgDb = DbContext.ImgNews
                .Where(img => img.News.Id == id)
                .ToList();

            var listImg = news.ImgsNews;

            listImgDb
                .ForEach(
                imgDb =>
                {
                    if (!listImg.Select(img => img.Url).Contains(imgDb.Url))
                        DbContext.ImgNews.Remove(imgDb);
                });

            listImg
                .ForEach(
                img =>
                {
                    if (!listImgDb.Select(img => img.Url).Contains(img.Url))
                        DbContext.News.FirstOrDefault(ev => ev.Id == id).ImgsNews.Add(img);
                });

            DbContext.SaveChanges();
        }

        public override void Delete(NewsEntity entity)
            => DbContext.News
            .Where(v => v.Id == entity.Id)
            .ExecuteDelete();
    }
}
