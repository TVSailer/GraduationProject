using CSharpFunctionalExtensions;

namespace Domain.Entitys
{
    public class CategoryEntity : Entity
    {
        public string Category { get; init; }

        public override string ToString() => Category;
    }
}

