using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataAccess.Postgres.Attributes;

namespace DataAccess.Postgres.Models
{
    public class DateAttendanceEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пж, впиши дату!")]
        public required string Date { get; set; }

        [ForeignKey(nameof(LessonEntity))]
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }
        public List<VisitorEntity>? Visitors { get; set; } = new();


        public required ApplicationDbContext DbContext { get; set; }
        [Date(ErrorMessage = "Такая дата уже есть!")]
        public DateForValid DateForValide 
            => new DateForValid { Date = Date, DbContext = DbContext, LessonId = LessonId };

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