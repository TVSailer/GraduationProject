using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Enum;

namespace DataAccess.Postgres.Models
{
    public class LessonScheduleEntity : Entity
    {
        [ForeignKey(name: nameof(LessonEntity))]
        public long LessonId { get; set; }
        public LessonEntity Lesson { get; set; }

        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public Day Day { get; set; }

        public LessonScheduleEntity()
        {

        }

        public LessonScheduleEntity(TimeOnly start, TimeOnly end, Day day)
        {
            Day = day;
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"{Day}: {Start}-{End}";
        }

        public bool TryRangeScheduleNow()
        {
            var date = DateTime.Now;

            if (Start.ToTimeSpan() >= date.TimeOfDay) return false;
            if (End.ToTimeSpan() <= date.TimeOfDay) return false;
            if (Day.ConvertDayOfWeek() != date.DayOfWeek) return false;

            return true;
        }
    }
}

