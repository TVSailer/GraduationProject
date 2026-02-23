namespace DataAccess.Postgres.Models
{
    public class NewsCategoryEntity : CategoryEntity
    {
        public List<NewsEntity> NewsEntities { get; private set; } = new();

        public NewsCategoryEntity() { }

        public NewsCategoryEntity(string category = "") : base(category: category)
        {
        }

    }
}

