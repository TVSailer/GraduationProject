using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class LessonScheduleEntity : ScheduleEntity
    {
        [ForeignKey(nameof(LessonEntity))]
        public long LessonId { get; private set; }
        public LessonEntity Lesson { get; private set; }

        public LessonScheduleEntity()
        {

        }

        public LessonScheduleEntity(TimeOnly start, TimeOnly end, Day day) : base(start, end, day)
        {
        }
    }
}

