using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repository
{
    public class NewsRepository
    {
        public readonly ApplicationDbContext DbContext;
        public NewsEntity News { get; private set; }

        public NewsRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public List<NewsEntity> Get()
            => DbContext.News
            .Include(e => e.ImgsNews)
            .AsNoTracking()
            .ToList() ?? throw new ArgumentNullException();

        public NewsEntity Get(int id)
            => DbContext.News
            .AsNoTracking()
            .Include(e => e.ImgsNews)
            .FirstOrDefault(v => v.Id == id) ?? throw new ArgumentNullException();

        public void Add(NewsEntity news)
        {
            DbContext.Add(news);
            DbContext.SaveChanges();
        }

        public void Update(int id, NewsEntity news)
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

        public void Delete(int id)
            => DbContext.Event
            .Where(v => v.Id == id)
            .ExecuteDelete();
    }
}
