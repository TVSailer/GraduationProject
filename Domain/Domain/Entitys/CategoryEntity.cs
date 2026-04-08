using CSharpFunctionalExtensions;

namespace Domain.Entitys
{
    public class CategoryEntity : Entity
    {
        private CategoryEntity() { }

        public CategoryEntity(string category)
        {
            Category = category;
        }

        public string Category { get; private set; }

        public override string ToString() => Category;
    }
}

