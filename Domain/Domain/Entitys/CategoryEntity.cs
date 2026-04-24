using CSharpFunctionalExtensions;
using Domain.Exception;
using Domain.ValidObject;

namespace Domain.Entitys
{
    public class CategoryEntity : Entity
    {
        public string Category { get; private set; }

        private CategoryEntity() { }

        public CategoryEntity(CategoryValidObject category)
        {
            Category = category.Text;
        }

        public override string ToString() => Category;
    }
}

