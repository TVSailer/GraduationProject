using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class DateAttendanceEntity : Entity
    {
        public string Date { get; private set; }

        [ForeignKey(nameof(LessonEntity))]
        public long LessonId { get; set; }
        public LessonEntity Lesson { get; private set; }

        public List<VisitorEntity>? Visitors { get; private set; } = new();

        public DateAttendanceEntity() { }

        public override string ToString()
            => Date.ToString();
    }
}