using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models
{
    public class LessonScheduleEntity : Entity
    {
        [ForeignKey(nameof(LessonEntity))]
        public long LessonId { get; private set; }
        public LessonEntity Lesson { get; set; }

        public TimeOnly Start { get; private set; }
        public TimeOnly End { get; private set; }
        public Day Day { get; private set; }

        public LessonScheduleEntity()
        {

        }

        public LessonScheduleEntity(TimeOnly start, TimeOnly end, Day day)
        {
            Day = day;
        }

        public override string ToString()
        {
            return $"{Day}: {Start}-{End}";
        }
    }

    
}

