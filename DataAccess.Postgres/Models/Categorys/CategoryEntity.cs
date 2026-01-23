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
            return base.Equals(other) && Category == other.Category;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CategoryEntity)obj);
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
            return Equals(left, right);
        }

        public static bool operator !=(CategoryEntity? left, CategoryEntity? right)
        {
            return !Equals(left, right);
        }
    }
}

