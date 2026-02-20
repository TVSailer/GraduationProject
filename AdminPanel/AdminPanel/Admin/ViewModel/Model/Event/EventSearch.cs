using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using WinFormsApp1.ViewModelEntity.Event;

public class EventSearch : IParametersSearch<EventEntity, EventFieldSearch>
{
    public Func<EventFieldSearch, List<EventEntity>, List<EventEntity>> SearchFunc =>
        (obj, entitys) =>
            entitys
                .Where(e => obj.Category.Equals(obj.category[0]) || e.Category.Equals(obj.Category))
                .Where(e => e.Title.StartsWith(obj.Title))
                .Where(e =>
                    !DateTime.TryParse(obj.StartDate, out _) || !DateTime.TryParse(obj.EndDate, out _) ||
                    DateTime.Parse(e.Schedule.Date) >= DateTime.Parse(obj.StartDate!) &&
                    DateTime.Parse(e.Schedule.Date) <= DateTime.Parse(obj.EndDate!))
                .ToList();
}