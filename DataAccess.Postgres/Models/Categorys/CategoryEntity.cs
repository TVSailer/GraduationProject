using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models
{
    public class CategoryEntity : Entity
    {
        public string Category { get; private set; }

        public CategoryEntity() { }

        public CategoryEntity(string category)
        {
            Category = category;
        }

        public override string ToString()
        {
            return $"{Category}";
        }
    }
}

