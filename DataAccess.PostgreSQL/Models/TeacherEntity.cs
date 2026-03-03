using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class TeacherEntity : Entity
    {
        public FIO FIO { get; set; }
        public string DateBirth { get; set; }
        public string NumberPhone { get; set; }

        [ForeignKey(nameof(AuthEntity))]
        public long AuthId { get; set; }
        public AuthEntity AuthEntity { get; set; }
        
        public List<LessonEntity> Lessons { get; set; } = [];
        public override string ToString() => FIO.ToString();
    }
}
