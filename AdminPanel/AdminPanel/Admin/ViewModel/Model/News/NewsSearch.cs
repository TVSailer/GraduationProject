using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Model.News;

public class NewsSearch : IParametersSearch<NewsEntity, NewsFieldSearch>
{
    public Func<NewsFieldSearch, List<NewsEntity>, List<NewsEntity>> SearchFunc =>
        (obj, entitys) =>
            entitys
                .Where(e => obj.Category == null || obj.Category.Equals(obj.Categorys[0]) || e.Category.Equals(obj.Category))
                .Where(e => e.Title.StartsWith(obj.Title ?? ""))
                .Where(e => e.Author.StartsWith(obj.Author ?? ""))
                .Where(e =>
                    e.DateT() >= obj.StartDateTime() &&
                    e.DateT() <= obj.EndDateTime())
                .ToList();
}