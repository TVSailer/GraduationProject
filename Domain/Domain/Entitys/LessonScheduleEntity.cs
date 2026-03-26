using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;
using Domain.Enum;
using Domain.Enum.Extension;

namespace Domain.Entitys
{
    public class LessonScheduleEntity : Entity
    {
        public LessonEntity Lesson { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public Day Day { get; set; }

        private LessonScheduleEntity() { }

        public LessonScheduleEntity(TimeOnly start, TimeOnly end, Day day)
        {
            Day = day;
            Start = start.ToString("HH:mm");
            End = end.ToString("HH:mm");
        }

        //public override string ToString()
        //{
        //    return $"{Day.ToDescriptionString()}: {Start}-{End}";
        //}

        public bool TryRangeScheduleNow()
        {
            var date = DateTime.Now;

            if (TimeOnly.Parse(Start).ToTimeSpan() >= date.TimeOfDay) return false;
            if (TimeOnly.Parse(End).ToTimeSpan() <= date.TimeOfDay) return false;
            if (Day.ConvertDayOfWeek() != date.DayOfWeek) return false;

            return true;
        }
    }
}

