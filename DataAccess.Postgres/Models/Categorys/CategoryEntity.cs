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

        protected bool Equals(CategoryEntity other)
        {
            return Category.Equals(value: other.Category);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(objA: this, objB: obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(other: (CategoryEntity)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Category.GetHashCode();
            }
        }

        public static bool operator ==(CategoryEntity? left, CategoryEntity? right)
        {
            return Equals(objA: left, objB: right);
        }

        public static bool operator !=(CategoryEntity? left, CategoryEntity? right)
        {
            return !Equals(objA: left, objB: right);
        }
    }
}

