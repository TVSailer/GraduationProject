using CSharpFunctionalExtensions;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys
{
    public class CategoryEntity : Entity
    {
        [Category] public string Category { get; set; }

        public override string ToString()
        {
            return $"{Category}";
        }
    }
}

