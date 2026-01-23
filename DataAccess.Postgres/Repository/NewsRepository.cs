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
            .Include(e => e.Imgs)
            .AsNoTracking()
            .ToList();

        public NewsEntity Get(int id)
            => DbContext.News
            .AsNoTracking()
            .Include(e => e.Imgs)
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

            if (news.Imgs == null || news.Imgs.Count == 0) return;

            var listImgDb = DbContext.ImgNews
                .Where(img => img.News.Id == id)
                .ToList();

            var listImg = news.Imgs;

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
                        DbContext.News.FirstOrDefault(ev => ev.Id == id).Imgs.Add(img);
                });

            DbContext.SaveChanges();
        }

        public override void Delete(NewsEntity entity)
            => DbContext.News
            .Where(v => v.Id == entity.Id)
            .ExecuteDelete();
    }
}
