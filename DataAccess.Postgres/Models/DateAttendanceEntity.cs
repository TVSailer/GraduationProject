using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class DateAttendanceEntity
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Пж, впиши дату!")]
        public string Date { get; private set; }

        [ForeignKey(nameof(LessonEntity))]
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; private set; }
        public List<VisitorEntity>? Visitors { get; private set; } = new();

        public ApplicationDbContext DbContext { get; private set; }
        [Date(ErrorMessage = "Такая дата уже есть!")]
        public DateForValid DateForValide 
            => new DateForValid { Date = Date, DbContext = DbContext, LessonId = LessonId };

        public DateAttendanceEntity() { }

        public override string ToString()
            => Date;

        public class DateForValid
        {
            public required ApplicationDbContext DbContext { get; set; }
            public required string Date { get; set; }
            public required int LessonId{ get; set; }
        }
    }
}