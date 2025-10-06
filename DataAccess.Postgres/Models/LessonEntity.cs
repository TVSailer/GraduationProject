using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class LessonEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пж, впиши название кружка!")]
        public required string Name { get; set; }

        [ForeignKey(nameof(TeacherEntity))]
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public List<DateAttendanceEntity>? Dates { get; set; } = new();
        public List<VisitorEntity>? Visitors { get; set; } = new();

        public override string ToString()
            => Name;
    }
}