using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models
{
    public class ScheduleEntity : Entity
    {
        public TimeOnly Start { get; private set; }
        public TimeOnly End { get; private set; }
        public Day Day { get; private set; }

        public ScheduleEntity()
        {

        }
        
        public ScheduleEntity(TimeOnly start, TimeOnly end, Day day)
        {
            Start = start;
            End = end;
            Day = day;
        }

        public override string ToString()
        {
            return $"{Day}: {Start}-{End}";
        }
    }
}

