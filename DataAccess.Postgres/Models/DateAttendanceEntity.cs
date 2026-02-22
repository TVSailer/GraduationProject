using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models
{
    public class DateAttendanceEntity : Entity
    {
        public string Date { get; set; } = DateTime.Now.ToString(format: "dd/MM/yyyy");

        [ForeignKey(name: nameof(LessonEntity))]
        public long LessonId { get; set; }
        public LessonEntity? Lesson { get; set; }

        public List<VisitorEntity>? Visitors { get; set; } = [];

        public override string ToString() => Date;
    }
}