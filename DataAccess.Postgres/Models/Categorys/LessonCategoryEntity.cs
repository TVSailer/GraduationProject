using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class LessonCategoryEntity : CategoryEntity
    {
        public List<LessonEntity> LessonEntities { get; private set; } = new();

        public LessonCategoryEntity() { }

        public LessonCategoryEntity(string category) : base(category)
        {
        }

    }
}

