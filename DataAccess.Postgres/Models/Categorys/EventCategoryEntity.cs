namespace DataAccess.Postgres.Models
{
    public class EventCategoryEntity : CategoryEntity
    {
        public List<EventEntity> EventEntities { get; private set; } = new();

        public EventCategoryEntity() { }

        public EventCategoryEntity(string category = "") : base(category: category)
        {
        }

    }
}

