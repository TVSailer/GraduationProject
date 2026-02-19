using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class DateAttendanceEntity : Entity
    {
        public string Date { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

        [ForeignKey(nameof(LessonEntity))]
        public long LessonId { get; set; }
        public LessonEntity? Lesson { get; set; }

        public List<VisitorEntity>? Visitors { get; set; } = [];

        public override string ToString() => Date;
    }
}