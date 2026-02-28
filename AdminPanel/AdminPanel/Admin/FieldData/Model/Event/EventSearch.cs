using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using WinFormsApp1.ViewModelEntity.Event;

public class EventSearch : IParametersSearch<EventEntity, EventFieldSearch>
{
    public Func<EventFieldSearch, List<EventEntity>, List<EventEntity>> SearchFunc =>
        (obj, entitys) =>
            entitys
                .Where(e => obj.Category == null || obj.Category.Equals(obj.Categorys[0]) || e.Category.Equals(obj.Category))
                .Where(e => e.Title.StartsWith(obj.Title ?? ""))
                .Where(e =>
                    e.Schedule.DateT() >= obj.StartDateTime() && 
                    e.Schedule.DateT() <= obj.EndDateTime())
                .ToList();
}